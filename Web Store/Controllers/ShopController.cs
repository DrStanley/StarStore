using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Controllers
{
	public class ShopController : Controller
	{
		private string userId;
		private ICart icart;
		private IShopTupleData shopTupleData;
		public ShopController(string UserId)
		{
			userId = UserId;
		}
		public ShopController()
		{
			shopTupleData = new ShopTupleData();
			icart = new CartServices();
		}

		public string UserId
		{
			get
			{
				return userId ?? HttpContext.User.Identity.GetUserId();
			}
			set
			{
				userId = value;
			}
		}

		// GET: Shop
		public ActionResult Index()
		{
			var tupleModel = shopTupleData.DisplayProduct(userId, null);
			return View(tupleModel);
		}

		[HttpPost]
		public ActionResult Index(string options)
		{
			var tupleModel = shopTupleData.DisplayProduct(userId, options);
			return View(tupleModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult AddToCart(int productID, int productQuantity)
		{

			Product product = new Product()
			{
				ProductID = productID,
				Quantity = productQuantity
			};

			icart.AddCart(product, userId);

			return RedirectToAction("Index", "Shop");
		}

		[HttpPost]
		[Authorize]
		public ActionResult RemoveCart(string cartID)
		{
			Cart cart = new Cart() { CartId = cartID };
			var res=  icart.RemoveCart(cart);
			if(res== "Success")
			{
				return RedirectToAction("VeiwCart", "Shop");

			}

			return View();
		}

		[Authorize]
		public ActionResult VeiwCart()
		{
			var cartProduct = icart.DisplayCarts(userId);
			return View(cartProduct);
		}
	}
}