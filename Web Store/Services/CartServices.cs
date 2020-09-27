using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class CartServices
	{
		public static ApplicationDbContext dbContext = new ApplicationDbContext();

		public static void AddCart(Product product, string userid)
		{
			try
			{
				Cart newCart = new Cart()
				{
					CartId = "Cart_" +DateTime.Now.Millisecond,
					ProductId = product.ProductID,
					DateCreated = DateTime.Now,
					Quantity = product.Quantity,
					UserId = userid
				};
				dbContext.carts.Add(newCart);
				dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}

		public static int GetCartCount(string userid)
		{
			int count = 0;
			try
			{
			 count = dbContext.carts
			   .Where(o => o.UserId == userid)
			   .Count();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return count;
		}

	}
}