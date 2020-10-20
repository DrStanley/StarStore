using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Web_Store.Interfaces;
using Web_Store.Models;
using Web_Store.Services;


namespace Web_Store.Controllers
{
	public class HomeController : Controller
	{
		IAdmin admin;
		private string userId;

		public HomeController(IAdmin iadmin)
		{
			admin = iadmin;
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
		public ActionResult Index()
		{
			// adding the first Admin
			AddAdminViewModel model = new AddAdminViewModel();
			model.Email = "oga@gmail.com";
			model.Password = "Stan115.";
			model.PhoneNumber = "08182878405";
			admin.Addadmin(model);

			try
			{
				if (User.IsInRole("Admin"))
				{
					return RedirectToAction("Index", "Admin");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


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