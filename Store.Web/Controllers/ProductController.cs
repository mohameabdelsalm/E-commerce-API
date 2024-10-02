using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Dto;
using Store.Service.Interface;

namespace Store.Web.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDto>>> GetAllBrands()
        
          =>  Ok(await _productService.GetAllBrandAsync());

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<BrandTypeDto>>> GetAllType()

       => Ok(await _productService.GetAllTypeAsync());
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProduct()

       => Ok(await _productService.GetAllProductAsync());
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProductById(int?Id)

       => Ok(await _productService.GetProductByIdAsync(Id));

    }
}
