using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class ProductServices : IProduct
	{
		public ApplicationDbContext dbContext ;
		ICategory categoryS;

		public ProductServices(ICategory icategory, ApplicationDbContext db)
		{
			categoryS = icategory;
			dbContext = db;
		}
		public ProductServices()
		{
		}
		public string AddNewProduct(AddProductViewModel addProduct, string userid)
		{
			try
			{
				Product newproduct = new Product()
				{
					ProductName = addProduct.ProductName,
					Description = addProduct.Description,
					CategoryID = categoryS.GetCategoryID(addProduct.Category),
					DateCreated = DateTime.Now,
					ExpieryDate = addProduct.ExpieryDate,
					Supplier = addProduct.Supplier,
					UnitPrice = addProduct.UnitPrice,
					Image = ProductServices.ImageConvertToByte(addProduct.AddImage),
				
					Quantity = addProduct.Quantity,
					UserId = userid
				};
				dbContext.products.Add(newproduct);
				dbContext.SaveChanges();
				return "Success";
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				return "An Error Occurred";
			}

			//at System.Data.Entity.Internal.InternalContext.SaveChanges()
			//at System.Data.Entity.Internal.LazyInternalContext.SaveChanges()
			//at System.Data.Entity.DbContext.SaveChanges()
			//at Web_Store.Services.ProductServices.AddNewProduct(AddProductViewModel addProduct, String userid) 
			//	in C: \Users\Stanley\source\repos\Web Store\Web Store\Services\ProductServices.cs:line 29
		}

		public List<ImagProduct> GetProducts(string category)
		{
			List<Product> products = new List<Product>();
			if (string.IsNullOrEmpty(category) || category == "All")
			{
				products = dbContext.products.ToList();
			}
			else
			{
				int cId = categoryS.GetCategoryID(category);
				products = dbContext.products.Where(o => o.CategoryID == cId)
					.ToList();

			}
			List<ImagProduct> ImagProducts = new List<ImagProduct>();
			foreach (var item in products)
			{
				ImagProduct imagProduct = new ImagProduct()
				{
					ProductID = item.ProductID,
					Description = item.Description,
					Image = ProductServices.ImageConvertToString(item.Image),
					DateCreated = item.DateCreated,
					ExpieryDate = item.ExpieryDate,
					ProductName = item.ProductName,
					Supplier = item.Supplier,
					UnitPrice = item.UnitPrice,
					Quantity = item.Quantity,
					CategoryID = item.CategoryID
				};
				ImagProducts.Add(imagProduct);
			}

			return ImagProducts;
		}

		public static string ImageConvertToString(byte[] bytes)
		{
			string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);

			return "data:image/png;base64," + base64String;
		}
		public static byte[] ImageConvertToByte(HttpPostedFileBase file)
		{
			Byte[] bytes = null;

			Stream fs = file.InputStream;

			BinaryReader br = new BinaryReader(fs);

			bytes = br.ReadBytes((Int32)fs.Length);

			return bytes;
		}
	}
}