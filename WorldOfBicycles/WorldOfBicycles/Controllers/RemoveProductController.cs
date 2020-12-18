using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System.Linq;

namespace WorldOfBicycles.Controllers
{
	public class RemoveProductController : Controller
	{
		DBContext dbContext;
		ShopCart shopCart;
		public RemoveProductController(DBContext dbContext, ShopCart shopCart)
		{
			this.dbContext = dbContext;
			this.shopCart = shopCart;
		}

		[HttpGet]
		public ActionResult Index(string category)

		{
			ShopViewModel products = new ShopViewModel();


			if (string.IsNullOrEmpty(category))
			{
				products.Products = dbContext.Products;
			}
			else
			{
				products.Products = dbContext.Products.Where(cat => cat.Category.Name.ToLower() == category.ToLower());
			}
			ViewBag.Controller = "RemoveProduct";
			ViewBag.Action = "Remove";
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(products);
		}

		public IActionResult Remove(int id)
		{
			var product = dbContext.Products.FirstOrDefault(i => i.Id == id);
			dbContext.Products.Remove(product);
			dbContext.SaveChanges();

			return Redirect("~/RemoveProduct/Index");
		}

	}
}
