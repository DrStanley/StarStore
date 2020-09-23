using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Store.Models
{
	public class AddProduct
	{
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Item Name")]
        public string ProductName { get; set; }

        [Required, Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]

        public DateTime DateCreated { get; set; }
        public DateTime ExpieryDate { get; set; }

        public decimal? UnitPrice { get; set; }
        public int? CategoryID { get; set; }

    }
}