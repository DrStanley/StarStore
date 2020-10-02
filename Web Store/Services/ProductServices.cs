using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class ProductServices : IProduct
	{
		public  ApplicationDbContext dbContext = new ApplicationDbContext();
		public  void AddNewProduct(AddProductViewModel addProduct, string userid)
		{
			try
			{
				Product newproduct = new Product()
				{
					ProductName = addProduct.ProductName,
					Description = addProduct.Description,
					CategoryID = CategoryServices.GetCategoryID(addProduct.Category),
					DateCreated = DateTime.Now,
					ExpieryDate = addProduct.ExpieryDate,
					Supplier = addProduct.Supplier,
					UnitPrice = addProduct.UnitPrice,
					ImagePath = addProduct.ImagePath,
					Quantity = addProduct.Quantity,
					UserId = userid
				};
				dbContext.products.Add(newproduct);
				dbContext.SaveChanges();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			//at System.Data.Entity.Internal.InternalContext.SaveChanges()
   //at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
   //at System.Data.Entity.DbContext.SaveChanges()
   //at Web_Store.Services.ProductServices.AddNewProduct(AddProductViewModel addProduct, String userid) 
			//	in C: \Users\Stanley\source\repos\Web Store\Web Store\Services\ProductServices.cs:line 29
		}

		public  List<Product> GetProducts(string category)
		{
			List<Product> all = new List<Product>();
			if (string.IsNullOrEmpty(category))
			{
				all = dbContext.products.ToList();
			}
			else
			{
				int cId = CategoryServices.GetCategoryID(category);
				all = dbContext.products.Where(o => o.CategoryID == cId)
					.ToList();

			}
			return all;
		}
	}
}