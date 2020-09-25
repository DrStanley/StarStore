using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var category = CategoryServices.GetCategory(null);
            var product = ProductServices.GetProducts(null);
            var tupleModel = new Tuple<List<Product>, List<string>>(product, category);
            return View(tupleModel);
        }

        [HttpPost]
        [Authorize]
        public JsonResult AddToCart(string cartItem)
        {
            // 0 = id, 1 = qantity
            string[] cart = cartItem.Split(',');
            return Json(cart);
        }
    }
}