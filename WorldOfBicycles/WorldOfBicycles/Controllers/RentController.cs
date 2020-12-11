using Microsoft.AspNetCore.Mvc;
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
			ViewBag.Action = "Index";
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(products);
		}

		[HttpPost]
		public IActionResult Index(Rent rent)
		{
			return View();
		}
	}
}
