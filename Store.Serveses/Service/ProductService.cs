using AutoMapper;
using Store.Data.Entites;
using Store.Repository.Interface;
using Store.Repository.Specifications.ProductSpec;
using Store.Service.Dto;
using Store.Service.Interface;

namespace Store.Service.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<BrandTypeDto>> GetAllBrandAsync()
        {
            var brands = await _unitOfWork.Repository<ProductBrand, int>().GetAllAsNoTrackingAsync();

            var mappedBrand =_mapper.Map<IReadOnlyList<BrandTypeDto>>(brands);

            return mappedBrand;
        }

        public async Task<IReadOnlyList<ProductDto>> GetAllProductAsync(ProductSpecification input)
        {
            var spec=new ProductsWithSpecification(input);
            var product = await _unitOfWork.Repository<Product, int>().GetAllWithSpecificationAsync(spec);
            var mappedProduct = _mapper.Map<IReadOnlyList<ProductDto>>(product);
            return mappedProduct;
        }

        public async Task<IReadOnlyList<BrandTypeDto>> GetAllTypeAsync()
        {
            var type = await _unitOfWork.Repository<ProductType, int>().GetAllAsNoTrackingAsync();

            IReadOnlyList<BrandTypeDto> mappedType = _mapper.Map<IReadOnlyList<BrandTypeDto>>(type);

            return mappedType;
        }

        public async Task<ProductDto> GetProductByIdAsync(int? Id)
        {
            if (Id is null)
                throw new Exception("Id is null");
            var spec= new ProductsWithSpecification(Id);
            var product = await _unitOfWork.Repository<Product, int>().GetWithSpecificationByIdAsync(spec);

            if (product == null)
                throw new Exception("Product not found");
            var MAppedProduct = _mapper.Map<ProductDto>(product);
            return MAppedProduct;
        }
    }
}
