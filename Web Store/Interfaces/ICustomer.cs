using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Models;

namespace Web_Store.Interfaces
{
	interface ICustomer
	{
		void CreateCustomers(RegisterViewModel registerCustomer, string userid);
	}
}
