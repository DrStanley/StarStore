using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web_Store.Entities;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Controllers
{
	public class ShopController : Controller
	{
		// GET: Shop
		public ActionResult Index()
		{

			var category = CategoryServices.GetCategory();
			var product = ProductServices.GetProducts(null);
			int CartCount = CartServices.GetCartCount(HttpContext.User.Identity.GetUserId());
			var tupleModel = new Tuple<List<Product>, List<string>,int>(product, category,CartCount);
			return View(tupleModel);
		}
		
		[HttpPost]
		public ActionResult Index(string options)
		{
			var category = CategoryServices.GetCategory();
			var product = ProductServices.GetProducts(options);
			int CartCount = CartServices.GetCartCount(HttpContext.User.Identity.GetUserId());
			var tupleModel = new Tuple<List<Product>, List<string>,int>(product, category,CartCount);
			return View(tupleModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult AddToCart(string productID, string productQuantity)
		{

			Product product = new Product();
			product.ProductID = Int32.Parse(productID);
			product.Quantity = Int32.Parse(productQuantity);

			CartServices.AddCart(product, HttpContext.User.Identity.GetUserId());

			return RedirectToAction("Index", "Shop");
		}
	}
}