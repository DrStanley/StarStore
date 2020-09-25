using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Controllers
{
	public class AdminController : Controller
	{
		// GET: Admin
		[Authorize(Roles = "Admin")]
		public ActionResult Index()
		{
			return View();
		}

		[Authorize(Roles = "Admin")]
		public ActionResult AddNewAdmin()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> AddNewAdmin(AddAdminViewModel model)
		{

			if (ModelState.IsValid)
			{
				string res = AdminServices.Addadmin(model);
				;

				if (res == "Successful")
				{
					ViewBag.ModelMessage = "Admin Created Successfully";
					await Task.Delay(5000);
					return RedirectToAction("Index", "Admin");
				}
				else
				{
					ViewBag.ModelMessage = "An Error Occoured";

				}

				return View("Index", model);

			}
			ViewBag.ModelMessage = "Failed to create Admin model Error \n";

			return View("AddNewAdmin", model);
		}

		[Authorize(Roles = "Admin")]
		public ActionResult AddNewProduct()
		{
			return View();
		}

		//[HttpPost]
		//public async Task<ActionResult> AddNewProduct(AddProductViewModel model)
		//{

		//	if (ModelState.IsValid)
		//	{
		//		//string res = AdminServices.Addadmin(model);

		//		//if (res == "Successful")
		//		//{
		//		//	ViewBag.ModelMessage = "Admin Created Successfully";
		//		//	await Task.Delay(5000);
		//		//	return RedirectToAction("Index", "Admin");
		//		//}
		//		//else
		//		//{
		//		//	ViewBag.ModelMessage = "An Error Occoured";

		//		//}

		//		return View("Index", model);

		//	}
		//	ViewBag.ModelMessage = "Failed to create Admin model Error \n";

		//	return View("AddNewAdmin", model);
		//}


		[Authorize(Roles = "Admin")]
		public ActionResult AddCategories()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddCategories(AddCategoryViewModel model)
		{

			if (ModelState.IsValid)
			{
				var userId = HttpContext.User.Identity.GetUserId();
				var e = CategoryServices.AddCategory(model, userId);
				if (e == "Saved")
				{
					return RedirectToAction("Index", "Home");
				}
				ViewBag.ModelMessage = "Category already Exist";

				return View(model);
			}
			ViewBag.ModelMessage = "Failed to create Category model Error \n";

			return View(model);
		}

	}
}