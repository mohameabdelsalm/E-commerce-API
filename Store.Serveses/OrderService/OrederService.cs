using AutoMapper;
using Store.Data.Entites;
using Store.Data.Entites.OrderEntity;
using Store.Repository.Interface;
using Store.Repository.Specifications.OrderSpec;
using Store.Service.Basket;
using Store.Service.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.OrderService
{
    public class OrederService : IOrederService
    {
        private readonly IBasketService _basketService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrederService(IBasketService basketService, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _basketService = basketService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<OrderDetailsDto> CreateOrderAsync(OrderDto model)
        {
            //Get Basket
            var basket = await _basketService.GetBasketAsync(model.BasketId);
            if (basket is null)
            {
                throw new Exception("Basket Is Not Existed");
            }

            #region Fill Order Item List With Item in the Basket

            var OrderItems = new List<OrderItemDto>();
            foreach (var BasketItem in basket.BaskItems)
            {
                var ProductItem = await _unitOfWork.Repository<Product, int>().GetByIdAsync(BasketItem.ProductId);
                if (ProductItem is null)
                {
                    throw new Exception($"Product with Id :{BasketItem.ProductId} Not Exist");
                }
                var OrderedItem = new ProductItem
                {
                    ProudctId = ProductItem.Id,
                    ProudctName = ProductItem.Name,
                    PictureUrl = ProductItem.PictureUrl,

                };
                var OrderItem = new OrderItem
                {
                    Price = ProductItem.Price,
                    Quantity = BasketItem.Quantity,
                    ProductItem = OrderedItem
                };
                var MappedOrderItem= _mapper.Map<OrderItemDto>(OrderItem);
                OrderItems.Add(MappedOrderItem);
            }
            #endregion

            #region Get Delivery Method
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod, int>().GetByIdAsync(model.DeliveryMethodId);
           
            if (deliveryMethod is null)
                 throw new Exception("The DeliveryMethod Is Provided");
            #endregion

            #region Calc SUbTotal
            var subTotal = OrderItems.Sum(item => item.Price * item.Quantity);
            #endregion

            #region Create Order
            var MappedShippindAddress = _mapper.Map<ShippingAddress>(model.ShippingAddress);
            var MapedOrderItem = _mapper.Map<List<OrderItem>>(OrderItems);

            var order = new Order
            {
                BasketId=model.BasketId,
                CreateAt = DateTime.Now,
                BuyerEmail = model.BuyerEmail,
                DeliveryMethodId=deliveryMethod.Id,
                ShippingAddress = MappedShippindAddress,
                OrderItems= MapedOrderItem,
                SubTotal= subTotal
            };
            await _unitOfWork.Repository<Order,Guid>().AddAsync(order);
            await _unitOfWork.CompleteAsync();
             var Mappedorder= _mapper.Map<OrderDetailsDto>(order);
            return Mappedorder;

            #endregion


        }
        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
       => await _unitOfWork.Repository<DeliveryMethod, int>().GetAllAsync();

        public async Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderAsync(string buyerEmail)
        {
            var specs = new OrderWithItemSpecification(buyerEmail);
            var order=await _unitOfWork.Repository<Order,Guid>().GetAllWithSpecificationAsync(specs);

            if (!order.Any())
                throw new Exception("You don,t have any orders yet!");

            var Mapped=_mapper.Map<List<OrderDetailsDto>>(order);
            return Mapped;
        }

       

        public async Task<OrderDetailsDto> GetOrderByIdAsync(Guid id)
        {
            var specs = new OrderWithItemSpecification(id);

            var order = await _unitOfWork.Repository<Order, Guid>().GetWithSpecificationByIdAsync(specs);

            if (order is null)
                throw new Exception($"There Is No order With Id {id}");

            var Mapped = _mapper.Map<OrderDetailsDto>(order);
            return Mapped;
        }
    }
}
