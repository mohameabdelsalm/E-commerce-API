using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Repository.Specifications.ProductSpec;
using Store.Service.Dto;
using Store.Service.Interface;
using Store.Web.Helper;

namespace Store.Web.Controllers
{
	[Authorize]
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
        [Cache(30)]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetAllProduct([FromQuery]ProductSpecification input)

       => Ok(await _productService.GetAllProductAsync(input));
        [HttpGet]
        public async Task<ActionResult<ProductDto>> GetProductById(int?Id)

       => Ok(await _productService.GetProductByIdAsync(Id));

    }
}
