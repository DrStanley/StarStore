using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class CustomerServices:ICustomer
	{
		public ApplicationDbContext dbContext = new ApplicationDbContext();

		public void CreateCustomers(RegisterViewModel registerCustomer, string userid)
		{

			Customer newcustomer = new Customer()
			{
				FirstName = registerCustomer.FirstName,
				LastName = registerCustomer.LastName,
				Address = registerCustomer.Address,
				DateCreated = DateTime.Now,
				UserId = userid

			};
			dbContext.customers.Add(newcustomer);
			dbContext.SaveChanges();

		}
	}
}