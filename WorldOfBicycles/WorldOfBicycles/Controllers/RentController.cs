using Microsoft.AspNetCore.Mvc;
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
		public IActionResult Index()
		{
			var categories = new RentViewModel();
			categories.Categories = db.Categories;
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(categories);
		}

		[HttpPost]
		public IActionResult Index(Rent rent)
		{
			return View();
		}
	}
}
