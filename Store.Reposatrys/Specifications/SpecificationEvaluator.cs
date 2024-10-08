using Microsoft.EntityFrameworkCore;
using Store.Data.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications
{
	public class SpecificationEvaluator<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
	{
		

		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> InputQuery, ISpecification<TEntity> spec)
		{
			var query = InputQuery;
			if (spec.Criteria is not null)

				if (spec.OrderBy is not null)
					query = query.OrderBy(spec.OrderBy);// x =>x.Name

			if (spec.OrderByDescending is not null)
				query = query.OrderByDescending(spec.OrderByDescending);

		 if (spec.IsPaganted)
				query=query.Skip(spec.Skip).Take(spec.Take);

			query = query.Where(spec.Criteria);// x => x.ProductTypeId==3
			query = spec.Include.Aggregate(query,(current, IncludeExp)=>current.Include(IncludeExp));
			return query;
			
		}
	}
}