using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Store.Entities
{
	public class Product
	{
        [ScaffoldColumn(false)]

        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Item Name")]
        public string ProductName { get; set; }

        [Required, Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public decimal? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}