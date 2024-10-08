using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.ProductSpec
{
   public class ProductCountWithSpecification:BaseSpecification<Product>
    {
		public ProductCountWithSpecification(ProductSpecification spec)
			: base(product => (!spec.ProductBrandId.HasValue || product.ProductBrandId == spec.ProductBrandId.Value) &&
									(!spec.ProductTypeId.HasValue || product.ProductTypeId == spec.ProductTypeId.Value)
			)
		{
			
		}

	}
}
