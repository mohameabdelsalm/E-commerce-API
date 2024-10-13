using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Basket;
using Store.Service.Basket.Dtos;

namespace Store.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketController : ControllerBase
	{
		private readonly IBasketService _basketService;

		public BasketController(IBasketService basket)
        {
			_basketService = basket;
		}

		[HttpGet("Id")]
		public async Task<ActionResult<CustomerBasketDto>> GetBasketAsync(string Id)
		=> Ok(await _basketService.GetBasketAsync(Id));

		[HttpPost]
		public async Task<ActionResult<CustomerBasketDto>> UpdateBasketAsync(CustomerBasketDto input)
		=> Ok(await _basketService.UpdateBasketAsync(input));

		[HttpDelete("Id")]
		public async Task<ActionResult<bool>> DeleteBasketAsync(string Id)
		=> Ok(await _basketService.DeleteBasketAsync(Id));
	}
}
