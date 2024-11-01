using AutoMapper;
using Microsoft.Extensions.Configuration;
using Store.Data.Entites;
using Store.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Mapping
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;
        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
                return $"{_configuration["BaseUrl"]}{source.PictureUrl}";

            return string.Empty;
        }
    }
}
