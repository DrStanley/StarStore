using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Web_Store.Models;

namespace Web_Store.Entities
{
	public class Product
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductID { get; set; }

		public string ProductName { get; set; }

		public string Description { get; set; }

		public string ImagePath { get; set; }
		public string Supplier { get; set; }

		public DateTime DateCreated { get; set; }
		public DateTime ExpieryDate { get; set; }

		public decimal? UnitPrice { get; set; }

		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		public int Quantity { get; set; }
		public int? CategoryID { get; set; }

		public virtual Category Category { get; set; }
	}
}