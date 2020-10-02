using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Models;
using Web_Store.Interfaces;

namespace Web_Store.Services
{
	public class CartServices : ICart
	{
		public  ApplicationDbContext dbContext = new ApplicationDbContext();

		public  void AddCart(Product product, string userid)
		{
			try
			{

				if (dbContext.carts.Any(o => o.ProductId == product.ProductID))
				{
					var quant = dbContext.carts.Where(c => c.ProductId == product.ProductID)
						.Select(c => c.Quantity).FirstOrDefault();
					quant += product.Quantity;
					var id = dbContext.carts.Where(c => c.ProductId == product.ProductID)
						.Select(c => c.CartId).FirstOrDefault();
					quant += product.Quantity;


					var cart = new Cart() { CartId = id, ProductId = product.ProductID, Quantity = quant };
					dbContext.carts.Attach(cart);
					dbContext.Entry(cart).Property(X => X.Quantity).IsModified = true;
					dbContext.SaveChanges();
				}
				else
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

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}


		public  string RemoveCart(Cart cart)
		{
			try
			{
				Cart cartToRemove = dbContext.carts.SingleOrDefault(c => c.CartId == cart.CartId);

				dbContext.carts.Attach(cartToRemove);
				dbContext.carts.Remove(cartToRemove);
				dbContext.SaveChanges();
				return "Success";
				
				//dbContext.Entry(cartToRemove).State = EntityState.Deleted;
				//dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				return "Error";

				Console.WriteLine(e.Message);
			}
		}

		public  int GetCartCount(string userid)
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

	

		public List<Product> GetCartProducts(List<Cart> carts)
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