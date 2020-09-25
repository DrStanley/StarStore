using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Store.Models
{
	public class AddCategoryViewModel
	{


		[Required(ErrorMessage = "Please enter a valid Category Name")]
		[Display(Name = "Category Name")]
		[StringLength(200, MinimumLength = 5)]
		public string CategoryName { get; set; }

		[Required(ErrorMessage = "Please enter a valid Category Description")]
		[Display(Name = "Category Description"), DataType(DataType.MultilineText)]
		[StringLength(1000, MinimumLength = 20)]
		public string Description { get; set; }
	}
}