using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System;
using System.Linq;

namespace WorldOfBicycles.Controllers
{
	public class AddToCartController : Controller
	{
		DBContext db;
		ShopCart shopCart;
		public AddToCartController(DBContext db, ShopCart shopCart)
		{
			this.db = db;
			this.shopCart = shopCart;
		}

	
		[HttpGet]
		public IActionResult Index(int id)
		{
			var product = db.Products.FirstOrDefault(i => i.Id == id);
			var obj = new AddToCartViewModel()
			{
				Product = product	
			};
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(obj);
		}


		[HttpPost]
		public void Index(string count)
		{
			int _count = Convert.ToInt32(count);
			if(_count <= 0)
			{
				_count = 0;
			}
		}
	}
}
