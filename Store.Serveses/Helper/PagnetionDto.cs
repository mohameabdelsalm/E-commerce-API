using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Helper
{
	public class PagnetionDto<T>
	{
		public PagnetionDto(int pageIndex, int pageSize, int totelCount, IReadOnlyList<T> data)
		{
			PageIndex = pageIndex;
			PageSize = pageSize;
			TotelCount = totelCount;
			Data = data;
		}

		public int PageIndex { get; set; }
		public int PageSize { get; set; }
		public int TotelCount { get; set; }
		public IReadOnlyList<T> Data { get; set; }
	}
}
