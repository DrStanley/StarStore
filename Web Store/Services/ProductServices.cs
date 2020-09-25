using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class ProductServices
	{
		public static ApplicationDbContext dbContext = new ApplicationDbContext();
		public static void AddNewProduct(AddProductViewModel addProduct, string userid)
		{

			Product newproduct   = new Product()
			{
				ProductName = addProduct.ProductName,
				Description = addProduct.Description,
				CategoryID = CategoryServices.GetCategoryID( addProduct.Category),
				DateCreated =DateTime.Now,
				ExpieryDate = addProduct.ExpieryDate,
				Supplier = addProduct.Supplier,
				UnitPrice = addProduct.UnitPrice,
				ImagePath = addProduct.ImagePath
			};
			dbContext.products.Add(newproduct);
			dbContext.SaveChanges();

		}

		public static List<string> GetProducts(string category)
		{
			List<string> all = new List<string>();
			all.Add("All");

			if (string.IsNullOrEmpty(category))
			{
				all.AddRange(dbContext.categories.Select(o => o.CategoryName).ToList());
			}
			else
			{
				all.AddRange(dbContext.categories
					.Where(o => o.CategoryName == category)
					.Select(o => o.CategoryName)
					.ToList());
			}
			return all;
		}
	}
}