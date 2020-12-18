using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;

namespace WorldOfBicycles.Controllers
{
	public class RentController : Controller
	{
		DBContext db;
		ShopCart shopCart;

		public RentController(DBContext db, ShopCart shopCart)
		{
			this.db = db;
			this.shopCart = shopCart;
		}

		[HttpGet]
		public ActionResult Index(string category)
		{
			RentViewModel products = new RentViewModel();
			if (string.IsNullOrEmpty(category))
			{
				products.Products = db.Products;
			}
			else
			{
				products.Products = db.Products.Where(cat => cat.Category.Name.ToLower() == category.ToLower());
			} 
			ViewBag.Controller = "Rent";
			ViewBag.Action = "СhooseQuantity";
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(products);
		}

		[HttpGet]
		public IActionResult СhooseQuantity(int id)
		{
			var product = db.Products.FirstOrDefault(i => i.Id == id);
			Rent rent = new Rent();
			rent.Product = product;
			var obj = new PaymentViewModel()
			{
				Rent = rent
			};
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(obj);
		}

		[HttpPost]
		public IActionResult Payment(Rent rent, int id)
		{
			Product product = db.Products.FirstOrDefault(x => x.Id == id);
			var payment = new PaymentViewModel();

			payment.Rent = new Rent();
			payment.Rent.Product = product;
			payment.Rent.ProductCount = rent.ProductCount;
			payment.Rent.Duration = rent.Duration;
			payment.Rent.Date = rent.Date;

			int sum = product.Price * rent.ProductCount * Convert.ToInt32(rent.Duration);

			payment.Rent.Sum = sum;
			ViewBag.ProductCount = shopCart.ProductCount();

			return View(payment);
		}
	}
}
