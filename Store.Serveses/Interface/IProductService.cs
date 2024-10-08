using Store.Repository.Specifications.ProductSpec;
using Store.Service.Dto;
using Store.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Interface
{
    public interface IProductService
    {
        Task<ProductDto> GetProductByIdAsync(int? Id);
        Task<PagnetionDto<ProductDto>> GetAllProductAsync(ProductSpecification spec);
        Task<IReadOnlyList<BrandTypeDto>> GetAllBrandAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllTypeAsync();
    }
}
