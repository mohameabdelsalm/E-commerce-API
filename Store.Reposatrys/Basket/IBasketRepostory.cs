using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Basket.Model
{
	public interface IBasketRepostory
	{
		Task<CustomerBasket> GetBasketAsync(string basketId);
		Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);
		Task<bool> DeleteBasketAsync(string basketId);
	}
}
