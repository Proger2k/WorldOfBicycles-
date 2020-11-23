 using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.Controllers
{
	public class AddToDataBaseController : Controller
	{
		DBContext dBContext;
		ShopCart shopCart; 
		public AddToDataBaseController(DBContext dBContext, ShopCart shopCart)
		{
			this.dBContext = dBContext;
			this.shopCart = shopCart;
		}

		[HttpGet]
		public ActionResult Index()
		{
			ViewBag.ProductCount = shopCart.ProductCount();
			return View();
		}
		[HttpPost]
		public RedirectToActionResult Index(Product product)
		{
			var category = dBContext.Categories.FirstOrDefault(cat => cat.Name == product.Cat);
			product.CategoryId = category.Id;
			product.Category = category;
			dBContext.Products.Add(product);
			dBContext.SaveChanges();

			return RedirectToAction("Index","Home");
		}
	}
}
