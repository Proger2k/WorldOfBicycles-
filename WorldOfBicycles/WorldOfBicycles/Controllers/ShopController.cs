﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;
using WorldOfBicycles.ViewModels;
using System.Linq;

namespace WorldOfBicycles.Controllers
{
	public class ShopController : Controller
	{
		DBContext db;
		ShopCart shopCart;
		public ShopController(DBContext db, ShopCart shopCart, UserManager<User> userManager)
		{
			this.db = db;
			this.shopCart = shopCart;
		}
		public ActionResult Index(string category)
		{ 
			ShopViewModel products = new ShopViewModel();
			if (string.IsNullOrEmpty(category))
			{
				products.Products = db.Products;
			}
			else 
			{
				products.Products = db.Products.Where(cat => cat.Category.Name.ToLower() == category.ToLower());
			}
			ViewBag.Controller = "AddToCart";
			ViewBag.Action = "Index";
			ViewBag.ProductCount = shopCart.ProductCount();
			return View(products);
		}
	}
}
