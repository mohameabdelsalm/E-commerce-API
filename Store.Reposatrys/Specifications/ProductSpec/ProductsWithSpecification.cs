using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.ProductSpec
{
	public class ProductsWithSpecification : BaseSpecification<Product>
	{
		public ProductsWithSpecification(ProductSpecification spec)
			: base(product => (!spec.ProductBrandId.HasValue || product.ProductBrandId == spec.ProductBrandId.Value) &&
									(!spec.ProductTypeId.HasValue || product.ProductTypeId == spec.ProductTypeId.Value)
			)
		{
			AddInclude(x => x.ProductBrand);
			AddInclude(x => x.ProductType);
			AddOrderBy(x => x.Name);

			if (!string.IsNullOrEmpty(spec.Sort))
			{
				switch (spec.Sort)
				{
					case "PriceAsc":
						AddOrderBy(x => x.Price);
						break;

					case "PriceDecs":
						AddOrderByDescending(x => x.Price);
						break;

					default:
						AddOrderBy(x => x.Name);
						break;

				}

			}

		}
		public ProductsWithSpecification(int?id)
			: base(product => product.Id == id) 
		{
			AddInclude(x => x.ProductBrand);
			AddInclude(x => x.ProductType);

		}
			
	}
}
