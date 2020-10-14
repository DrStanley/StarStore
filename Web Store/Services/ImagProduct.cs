using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Store.Services
{
	public class ImagProduct
	{
		public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string Description { get; set; }

		public string Image { get; set; }
		public string Supplier { get; set; }

		public DateTime DateCreated { get; set; }
		public DateTime ExpieryDate { get; set; }

		public decimal? UnitPrice { get; set; }
		public int Quantity { get; set; }
		public int CategoryID { get; set; }

	}
}