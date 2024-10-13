﻿using StackExchange.Redis;
using Store.Repository.Basket.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Repository.Basket
{
	public class BasketRepostory : IBasketRepostory
	{
		private readonly IDatabase _database;
		public BasketRepostory (IConnectionMultiplexer redis)
		{
			_database = redis.GetDatabase();

		}
		public async Task<bool> DeleteBasketAsync(string basketId)
		=> await _database.KeyDeleteAsync(basketId);

		public async Task<CustomerBasket> GetBasketAsync(string basketId)
		{
			var basket=await _database.StringGetAsync(basketId);
			return basket.IsNullOrEmpty?null:JsonSerializer.Deserialize<CustomerBasket>(basket);
		}

		public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
		{
			var IsUpdated = await _database.StringSetAsync(basket.Id,JsonSerializer.Serialize(basket),TimeSpan.FromDays(30));
			if (IsUpdated)
               return await GetBasketAsync(basket.Id);

			return null;



		}
	}
}
