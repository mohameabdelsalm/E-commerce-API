using Store.Data.Entites.IdentityEntites;
using Store.Data.Entites.OrderEntity;
using Store.Service.OrderService.Dto;

namespace Store.Service.OrderService.Dto
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public AddressDto ShippingAddress { get; set; }
        public OrderPaymentStatus PaymentStatus { get; set; } = OrderPaymentStatus.pendding;
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public string DeliveryMethodName { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal ShippingPrice { get; set; }
        public string? BasketId { get; set; }
    }
}
