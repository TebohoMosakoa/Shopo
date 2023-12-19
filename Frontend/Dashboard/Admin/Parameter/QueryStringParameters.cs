﻿namespace Admin.Parameter
{
	public class QueryStringParameters
	{
		public String? SearchTerm { get; set; }
		const int maxPageSize = 50;
		public int PageNumber { get; set; } = 1;
		private int _pageSize = 8;
		public int PageSize
		{
			get
			{
				return _pageSize;
			}
			set
			{
				_pageSize = (value > maxPageSize) ? maxPageSize : value;
			}
		}
	}
}
