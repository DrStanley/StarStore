using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Store.Interfaces;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Controllers
{
	public class HomeController : Controller
	{
		IAdmin admin;

		public HomeController(IAdmin iadmin)
		{
			admin = iadmin;
		}
		public ActionResult Index()
		{
			// adding the first Admin
			AddAdminViewModel model = new AddAdminViewModel();
			model.Email = "oga@gmail.com";
			model.Password = "Stan115.";
			model.PhoneNumber = "08182878405";
			admin.Addadmin(model);

			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}