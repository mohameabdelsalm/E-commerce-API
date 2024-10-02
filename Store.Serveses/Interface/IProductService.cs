using Store.Service.Dto;
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
        Task<IReadOnlyList<ProductDto>> GetAllProductAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllBrandAsync();
        Task<IReadOnlyList<BrandTypeDto>> GetAllTypeAsync();
    }
}
