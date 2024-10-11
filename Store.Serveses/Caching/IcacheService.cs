using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Caching
{
	public interface IcacheService
	{
		Task SetCacheResponseAsync(string Key, object Response, TimeSpan TimeTolive);
		Task<string> GetCacheResponseAsync(string Key);
	}
}
