using Store.Data.Entites;
using Store.Service.OrderService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.OrderService
{
    public interface IOrederService
    {
        Task<OrderDetailsDto>CreateOrderAsync(OrderDto model);
        Task<IReadOnlyList<OrderDetailsDto>> GetAllOrderAsync(string buyerEmail);
        public Task<OrderDetailsDto> GetOrderByIdAsync(Guid id);
        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
