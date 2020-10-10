using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Models;

namespace Web_Store.Interfaces
{
	public interface IAdmin
	{
	 string Addadmin(AddAdminViewModel AdminDetails);
	}
}