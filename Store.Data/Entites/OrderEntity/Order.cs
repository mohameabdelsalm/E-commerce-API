using Store.Data.Entites.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Entites.OrderEntity
{
    public class Order:BaseEntity<Guid>
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
        public ShippingAddress ShippingAddress { get; set; }
        public OrderStatus Status { get; set; }=OrderStatus.Placed;
        public OrderPaymentStatus PaymentStatus { get; set; }=OrderPaymentStatus.pendding;
        public int? DeliveryMethodId { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public decimal SubTotal { get; set; }

        //public string PaymentIntendId { get; set; }
        public decimal GetTotal()
            => SubTotal + DeliveryMethod.Price;
        public string? BasketId { get; set; }

       
    }

    
}
