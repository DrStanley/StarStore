using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
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

	}
}