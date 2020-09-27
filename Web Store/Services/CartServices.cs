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
					CartId = "Cart_" + DateTime.Now.Millisecond,
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

		public static Tuple<List<Product>, List<Cart>> DisplayCarts(string userid)
		{
			List<Cart> carts = new List<Cart>();
			int cId = CategoryServices.GetCategoryID(userid);
			carts = dbContext.carts.Where(o => o.UserId == userid)
				.ToList();
			List<Product> cartproducts = new List<Product>();
			cartproducts = CartServices.GetCartProducts(carts);
			Tuple<List<Product>, List<Cart>> tuple = new Tuple<List<Product>, List<Cart>>(cartproducts,carts);

			return tuple;
		}

		public static List<Product> GetCartProducts( List<Cart> carts)
		{
			List<Product> cartproducts = new List<Product>();

			foreach (var cart in carts)
			{
				cartproducts.Add(dbContext.products.Where(o => o.ProductID == cart.ProductId)
								.SingleOrDefault());
			}

			return cartproducts;
		}

	}
}