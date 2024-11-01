using AutoMapper;
using Store.Data.Entites.OrderEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.OrderService.Dto
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<ShippingAddress,AddressDto>().ReverseMap();

            CreateMap<Order,OrderDetailsDto>()
             .ForMember(dest => dest.DeliveryMethodName, options => options.MapFrom(src => src.DeliveryMethod.ShortName))
             .ForMember(dest => dest.ShippingPrice, options => options.MapFrom(src => src.DeliveryMethod.Price));

            CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.ProudctId, options => options.MapFrom(src => src.ProductItem.ProudctId))
            .ForMember(dest => dest.ProudctName, options => options.MapFrom(src => src.ProductItem.ProudctName))
            .ForMember(m => m.PictureUrl, o => o.MapFrom<OrderPictureUrlResolver>()).ReverseMap();

        }
    }
}
