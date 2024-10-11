using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Service.Caching
{
	public class cacheService : IcacheService
	{
		private readonly IDatabase _database;
        public cacheService(IConnectionMultiplexer redis)
        {
			_database=redis.GetDatabase();     
			
        }
        public async Task<string> GetCacheResponseAsync(string Key)
		{
			var cache = await _database.StringGetAsync(Key);
			if (cache.IsNullOrEmpty)
				return null;
			return cache.ToString();
		}

		public async Task SetCacheResponseAsync(string Key, object Response, TimeSpan TimeTolive)
		{
			if (Response is null)
				return;
			var options = new JsonSerializerOptions { PropertyNamingPolicy= JsonNamingPolicy.CamelCase};
			var serializedResponssed=JsonSerializer.Serialize(Response,options);
			await _database.StringSetAsync(Key, serializedResponssed,TimeTolive);

		}

	
	}
}
