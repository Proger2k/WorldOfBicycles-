using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.Controllers
{
	public class OrderController : Controller
	{
		DBContext dbContext;
		ShopCart shopCart;
		IServiceProvider services;
		public OrderController(DBContext dbContext, ShopCart shopCart, IServiceProvider services)
		{
			this.dbContext = dbContext;
			this.shopCart = shopCart;
			this.services = services;
		}
		public RedirectToActionResult Order()
		{
			shopCart.RemoveShopCart(services);
		    foreach(var i in dbContext.Products)
			{
				i.ProductCountInShopCart = 0;
			}
			dbContext.SaveChanges();

			return RedirectToAction("Index", "Home");
		}
	}
}
