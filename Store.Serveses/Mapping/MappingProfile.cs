using AutoMapper;
using Store.Data.Entites;
using Store.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.TypeName, options => options.MapFrom(src => src.ProductType.Name))
            .ForMember(m => m.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<ProductType, BrandTypeDto>();
            CreateMap<ProductBrand, BrandTypeDto>();
        }
    }
}
