using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using RedWillow.MvcToastrFlash;
using Web_Store.Entities;
using Web_Store.Interfaces;
using Web_Store.Models;

namespace Web_Store.Controllers
{
	public class ProductController : Controller
	{
		private string userId;

		private IProduct iproduct;

		public ProductController(string UseurId)
		{
			userId = UserId;
		}

		public ProductController(IProduct product)
		{
			iproduct = product;

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


		// GET: Product
		[Authorize(Roles = "Admin")]
		public ActionResult AddNewProduct()
		{
			//ViewBag.CategoryList = CategoryServices.GetCategory(null);
			return View();
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]

		public ActionResult AddNewProduct(AddProductViewModel model, HttpPostedFileBase file)
		{

			try
			{
				if (file != null && file.ContentLength > 0)
				{

					if (file.FileName != null)

					{
						model.AddImage = file;
						if (ModelState.IsValid)
						{
							var res = iproduct.AddNewProduct(model, UserId);
							if (res == "Success")
							{
								ViewBag.ModelMessage = model.ProductName + " Product Added";
								return View(model);
							}
							else
							{
								ViewBag.ModelMessage = "Error Occurred";
								return View(model);
							}

						}
					}
				}
				else
				{
					ViewBag.ModelMessage = "Please Upload an Image";
					return View(model);

				}
			}
			catch (Exception ex)
			{
				ViewBag.Message = "ERROR:" + ex.Message.ToString();
			}



			ViewBag.ModelMessage = "An Error Ocurred in Model";
			return View(model);
		}


		[Authorize(Roles = "Admin")]
		public ActionResult RemoveProduct()
		{
			var imgProduct = iproduct.GetProducts(null);
			return View(imgProduct);
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public ActionResult RemoveProduct(int productID)
		{
			Product product = new Product() { ProductID = productID };
			var res = iproduct.RemoveProduct(product);
			if (res == "Success")
			{
				this.Flash(Toastr.SUCCESS, "Alert", "Item Removed");
				return View("RemoveProduct");
			}
			this.Flash(Toastr.SUCCESS, "Alert", "Error Removed");

			return View();
		}

	}
}