using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;

namespace WorldOfBicycles.Controllers
{
	public class ProfileController : Controller
	{
		DBContext db;
		ShopCart shopCart;

		public ProfileController(DBContext db, ShopCart shopCart)
		{
			this.db = db;
			this.shopCart = shopCart;
		}

		[HttpGet]
		public IActionResult Index()
		{
			IEnumerable<Rent> Rents = db.Rents.Where(x => x.User.UserName == User.Identity.Name).ToList();

			foreach(var item in Rents)
			{
				item.Product = db.Products.FirstOrDefault(x => x.Id == item.ProductId);
				item.Product.Category = db.Categories.FirstOrDefault(x => x.Id == item.Product.CategoryId);
			}

			var profile = new ProfileViewModel()
			{
				rents = Rents
			};
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(profile);
		}

		[HttpPost]
		public RedirectToActionResult FinishThePayment(Rent rent, int id)
		{
			rent.Product = db.Products.FirstOrDefault(x => x.Id == id);
			rent.Product.Category = db.Categories.FirstOrDefault(x => x.Id == rent.Product.CategoryId);
			rent.User = new User();
			rent.User.UserName = User.Identity.Name;
			Random rnd = new Random();
			rent.Code = Convert.ToString(rnd.Next(10000000, 99999999));
			db.Rents.Add(rent);
			db.SaveChanges();
			
			return RedirectToAction("Index");
		}
	}
}
