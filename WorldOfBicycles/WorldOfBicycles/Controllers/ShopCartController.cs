using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System.Linq;

namespace WorldOfBicycles.Controllers
{
	public class ShopCartController : Controller
	{
		DBContext dbContext;
		ShopCart shopCart;
		ShopCartViewModel obj;
		public ShopCartController(DBContext dbContext, ShopCart shopCart)
		{
			this.dbContext = dbContext;
			this.shopCart = shopCart;
		}
		[Authorize(Roles ="admin")]
		public ViewResult Index(int id)
		{
			var items = shopCart.GetShopItems();
			shopCart.ShopCartItems = items;

			var product = dbContext.Products.FirstOrDefault(i => i.Id == id);
			var shopCartItem = shopCart.ShopCartItems.FirstOrDefault(i => i.Product == product);

			if(shopCartItem != null)
			{
				shopCart.ShopCartItems.Remove(shopCartItem);
				dbContext.ShopCartItems.Remove(shopCartItem);
				product.ProductCountInShopCart = 0;
				dbContext.SaveChanges();
			}

			obj = new ShopCartViewModel()
			{
				ShopCart = shopCart,
				Total = shopCart.Total()
			};
			ViewBag.ProductCount = shopCart.ProductCount();

			return View(obj); 
		}
		public RedirectToActionResult AddToCart(Product prod, int id)
		{
			var product = dbContext.Products.FirstOrDefault(i => i.Id == id);

			if (product.ProductCountInShopCart == 0)
			{
				if (product != null)
				{
					product.ProductCountInShopCart = prod.Count;
					shopCart.AddToCart(product);
				}
			}
			else
			{
				product.ProductCountInShopCart += prod.Count;
				dbContext.SaveChanges();
			}

			return RedirectToAction("Index");
		}

		public ViewResult Payment()
		{
			return View();
		}
	}
}
