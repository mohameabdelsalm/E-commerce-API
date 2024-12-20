﻿using Store.Repository.Basket.Model;
using Store.Service.Basket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Basket
{
	public interface IBasketService
	{
		Task<CustomerBasketDto> GetBasketAsync(string basketId);
		Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket);
		Task<bool> DeleteBasketAsync(string basketId);
	}
}
