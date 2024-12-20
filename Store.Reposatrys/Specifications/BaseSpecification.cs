﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications
{
	public class BaseSpecification<T> : ISpecification<T>
	{
		public BaseSpecification(Expression<Func<T, bool>> criteria)
		{
			Criteria = criteria;
		}

		public Expression<Func<T, bool>> Criteria { get; }

		public List<Expression<Func<T, object>>> Include { get; } = new List<Expression<Func<T, object>>>();

		public Expression<Func<T, object>> OrderBy { get; private set; }
		public Expression<Func<T, object>> OrderByDescending { get; private set; }

		public int Take { get; private set; }

		public int Skip { get; private set; }

		public bool IsPaganted { get; private set; }

		protected void AddInclude(Expression<Func<T, object>> IncludeExp)
		
	    => Include.Add(IncludeExp);

		protected void AddOrderBy(Expression<Func<T, object>> orderByExperssion)
			=> OrderBy= orderByExperssion;
		protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExperssion)
			=> OrderBy = orderByDescendingExperssion;

		protected void ApplyPagination(int skip, int take)
		{
			Take = take;
			Skip = skip;
			IsPaganted= true;
		}



	}
}
