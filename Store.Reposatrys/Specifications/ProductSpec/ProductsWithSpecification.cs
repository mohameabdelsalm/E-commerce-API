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
			: base(product => (!spec.ProductBrandId.HasValue ||product.ProductBrandId==spec.ProductBrandId.Value)&&
			                        (!spec.ProductTypeId.HasValue || product.ProductTypeId == spec.ProductTypeId.Value)
			)
		{
			AddInclude(x=>x.ProductBrand);
			AddInclude(x => x.ProductType);
		}
	}
}
