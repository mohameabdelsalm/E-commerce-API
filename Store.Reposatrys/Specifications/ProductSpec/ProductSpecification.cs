using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.Specifications.ProductSpec
{
	public class ProductSpecification
	{
		public int? ProductTypeId { get; set; }
		public int? ProductBrandId { get; set; }
		public string? Sort { get; set; }

		public int PageIndex { get; set; } = 1;
		private const int MAXPAGESIZE = 30;

		private int _PageSize;

		public int PageSize
		{
			get => _PageSize; 
			set => _PageSize = value>MAXPAGESIZE?int.MaxValue:value; 
		}

		private string? _Search;

		public string? Search
		{
			get => _Search;
			set => _Search = value?.Trim().ToLower();
		}


	}
}
