using AutoMapper;
using Store.Repository.Basket.Model;
using Store.Service.Basket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Basket.AutoMapper
{
	public class BasketProfile:Profile
	{
        public BasketProfile()
        {
            CreateMap<CustomerBasket,CustomerBasketDto>().ReverseMap();
			CreateMap<BaskItem,BaskItemDto>().ReverseMap();

		}
    }
}
