﻿using Store.Repository.Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Basket.Dtos
{
	public class CustomerBasketDto
	{
		public string? Id { get; set; }
		public int? DeliveryMethodId { get; set; }
		public decimal ShippingPrice { get; set; }
		public List<BaskItemDto> BaskItems { get; set; } = new List<BaskItemDto>();
	}
}
