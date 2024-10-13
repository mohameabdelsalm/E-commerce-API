using Store.Data.Entites;

namespace Store.Repository.Basket.Model
{
	public class BaskItem
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string PictureUrl { get; set; }

		public string ProductTypeName { get; set; }
		
		public string ProductBrandName { get; set; }
		
	}
}