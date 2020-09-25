using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Store.Models
{
	public class AddProductViewModel
	{
        [Required(ErrorMessage = "Please enter a valid Product Name")]
        [ Display(Name = "Product Name")]
        [StringLength(200, MinimumLength = 5)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a valid Product Description"), 
            Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        [StringLength(1000, MinimumLength = 20)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Expiry Date")]
        [Required(ErrorMessage = "Please choose an Expiery Date")]
        public DateTime ExpieryDate { get; set; }

        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "Please enter a valid Price")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "Product Category")]
        [Required(ErrorMessage = "Please enter a valid Product Category")]
        public string Category { get; set; }

        [Display(Name = "Product Supplier")]
        [Required(ErrorMessage = "Please enter a valid Product Supplier")]
        public string Supplier { get; set; }

    }
}