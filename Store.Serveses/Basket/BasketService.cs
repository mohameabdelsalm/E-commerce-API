using AutoMapper;
using Store.Repository.Basket.Model;
using Store.Service.Basket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Basket
{
	public class BasketService : IBasketService
	{
		private readonly IBasketRepostory _basket;
		private readonly IMapper _mapper;

		public BasketService(IBasketRepostory basket,IMapper mapper)
        {
			_basket = basket;
			_mapper = mapper;
		}
        public async Task<bool> DeleteBasketAsync(string basketId)
		=> await _basket.DeleteBasketAsync(basketId);

		public async Task<CustomerBasketDto> GetBasketAsync(string basketId)
		{
			var basket=await _basket.GetBasketAsync(basketId);

			if(basket==null)
				return new CustomerBasketDto();

			var mappedBasket=_mapper.Map<CustomerBasketDto>(basket);
			return mappedBasket;
		}

		public async Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto input )
		{
			if (input.Id is null)
				input.Id =GenerateRendomBasketId();

			//Map in case SetBasket In CacheMemory Map From CustomerBasketDto To CustomerBasket
			var MapBasket = _mapper.Map<CustomerBasket>(input);
			var UpdateBasket =await _basket.UpdateBasketAsync(MapBasket);

			//Map in case Get Basket from CacheMemory Map From CustomerBasket(UpdateBasket) To CustomerBasketDto
			var MapBacketDto =  _mapper.Map<CustomerBasketDto>(UpdateBasket);
			return MapBacketDto;
		}
		private string GenerateRendomBasketId()
		{
			Random random = new Random();
			var basketId = random.Next(1000,10000);
			return $"BS-{basketId}";
		}
	}
}
