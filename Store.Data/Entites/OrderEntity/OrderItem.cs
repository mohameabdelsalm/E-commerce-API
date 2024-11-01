namespace Store.Data.Entites.OrderEntity
{
    public class OrderItem : BaseEntity<Guid>
    {
        public ProductItem ProductItem { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}