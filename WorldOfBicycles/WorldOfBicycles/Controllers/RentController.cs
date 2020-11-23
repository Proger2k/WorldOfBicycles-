using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;

namespace WorldOfBicycles.Controllers
{
	public class RentController : Controller
	{
		DbContext db;
		ShopCart shopCart;
		User user;
		public RentController(DbContext db, ShopCart shopCart, User user)
		{
			this.db = db;
			this.shopCart = shopCart;
			this.user = user;
		}

		[HttpGet]
		public IActionResult Index()
		{
			var categories = new RentViewModel();
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
