using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data.Models;

namespace WorldOfBicycles.Controllers
{
	public class ChatController : Controller
	{
		ShopCart shopCart;
		public ChatController(ShopCart shopCart)
		{
			this.shopCart = shopCart;
		}
		[Authorize]
		public IActionResult Index()
		{
			ViewBag.ProductCount = shopCart.ProductCount();
			return View();
		}
	}
}
