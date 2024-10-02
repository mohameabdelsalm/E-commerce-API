using Store.Data.Entites;
using Store.Repository.Interface;
using Store.Service.Dto;
using Store.Service.Interface;

namespace Store.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<BrandTypeDto>> GetAllBrandAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();

            IReadOnlyList<BrandTypeDto> mappedBrand = brands.Select(x => new BrandTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt

            }).ToList();

            return mappedBrand;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductAsync()
        {
            var product = await _unitOfWork.Repository<Product, int>().GetAllAsNoTrackingAsync();
            var mappedProduct = product.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                PictureUrl = x.PictureUrl,
                Price = x.Price,
                CreateAt = x.CreateAt,
                BrandName = x.ProductBrand.Name,
                TypeName = x.ProductType.Name,


            }).ToList();
            return mappedProduct;
        }

        public async Task<IReadOnlyList<BrandTypeDto>> GetAllTypeAsync()
        {
            var type = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();

            IReadOnlyList<BrandTypeDto> mappedType = type.Select(x => new BrandTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                CreateAt = x.CreateAt

            }).ToList();

            return mappedType;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? Id)
        {
            if (Id is null)
                throw new Exception("Id is null");
            var product = await _unitOfWork.Repository<Product, int>().GetByIdAsync(Id.Value);

            if (product == null)
                throw new Exception("Product not found");
            var MAppedProduct = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                PictureUrl = product.PictureUrl,
                CreateAt = product.CreateAt,
                BrandName = product.ProductBrand.Name,
                TypeName = product.ProductType.Name,
            };
            return MAppedProduct;
        }
    }
}
