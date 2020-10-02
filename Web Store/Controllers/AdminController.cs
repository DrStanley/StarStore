using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Web_Store.Interfaces;
using Web_Store.Models;
using Web_Store.Services;

namespace Web_Store.Controllers
{
	public class AdminController : Controller
	{
		private  string userId;

		private ICart icart;
		private IAdmin iadmin;
		private IProduct iproduct;
		private ICategory icategory;
		public AdminController(string UserId)
		{
			userId = UserId;
		}

		public AdminController()
		{
			icart = new CartServices();
			iadmin = new AdminServices();
			iproduct = new ProductServices();
			icategory = new CategoryServices();

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

		//GET: Admin
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
				string res = iadmin.Addadmin(model);
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
			//ViewBag.CategoryList = CategoryServices.GetCategory(null);
			return View();
		}

		[HttpPost]
		public ActionResult AddNewProduct(AddProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				iproduct.AddNewProduct(model, userId);
				ViewBag.Mess = model.ProductName+"Product Added";
				return View();

			}
				ViewBag.Mess ="An Error Ocurred";

			return View(model);
		}


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
				var e = icategory.AddCategory(model, userId);
				if (e == "Saved")
				{
					TempData["Success"] = model.CategoryName + " Added";
					ViewBag.Mess = model.CategoryName+" Added";
					return View(); ;
				}
				ViewBag.ModelMessage = "Category already Exist";

				return View(model);
			}
			ViewBag.ModelMessage = "Failed to create Category model Error \n";

			return View(model);
		}

	}
}