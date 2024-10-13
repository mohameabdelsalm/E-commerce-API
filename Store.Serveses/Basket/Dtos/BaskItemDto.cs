using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Basket.Dtos
{
	public class BaskItemDto
	{
		[Required]
		[Range(1,int.MaxValue)]
		public int ProductId { get; set; }
		[Required]
		public string ProductName { get; set; }

		[Required]
		[Range(0.1, double.MaxValue,ErrorMessage ="Price Must Be Greater Than Zero")]
		public decimal Price { get; set; }
		[Required]
		[Range(1,10, ErrorMessage = "Quantity Must Between 1 To 10 Pieces")]
		public int Quantity { get; set; }
		[Required]
		public string PictureUrl { get; set; }
		[Required]

		public string ProductTypeName { get; set; }
		[Required]

		public string ProductBrandName { get; set; }
	}
}
