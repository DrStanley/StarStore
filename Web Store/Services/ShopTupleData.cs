using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Services
{
	public class ShopTupleData : IShopTupleData
	{
		public ApplicationDbContext dbContext = new ApplicationDbContext();

		public CartServices cartServices;
		public ProductServices productServices;
		public CategoryServices categoryServices;

		public ShopTupleData()
		{
			categoryServices = new CategoryServices();
			productServices = new ProductServices();
			cartServices = new CartServices();

		}
		public Tuple<List<Product>, List<string>, int> DisplayProduct(string userid,string category=null)
		{
			var categories = categoryServices.GetCategory();
			var product = productServices.GetProducts(category);
			int CartCount = cartServices.GetCartCount(userid);
			var tuple = new Tuple<List<Product>, List<string>, int>(product, categories, CartCount);

			return tuple;
		}

		public Tuple<List<Product>, List<Cart>> DisplayCarts(string userid)
		{
			List<Cart> carts = new List<Cart>();
			int cId = categoryServices.GetCategoryID(userid);
			carts = dbContext.carts.Where(o => o.UserId == userid)
				.ToList();
			List<Product> cartproducts = new List<Product>();
			cartproducts = cartServices.GetCartProducts(carts);
			Tuple<List<Product>, List<Cart>> tuple = new Tuple<List<Product>, List<Cart>>(cartproducts, carts);

			return tuple;
		}
	}
}