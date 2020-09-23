using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web_Store.Models
{
	public class AddAdminViewModel
	{

		[EmailAddress]
		[Required(ErrorMessage = "Please a valid email address")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Please enter a valid password")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Confirm Password")]
		[Compare("Password", ErrorMessage = "Password and confirm password do not match")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Please enter a valid phone number")]
		public string PhoneNumber { get; set; }

	}
}