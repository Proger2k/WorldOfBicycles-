using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.Data.Models
{
	public class ShopCart
	{
		public string ShopCartId { get; set; }
		public List<ShopCartItem> ShopCartItems { get; set; }

		DBContext dbContext;
		public ShopCart(DBContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public int Total()
		{
			int total = 0;
			foreach(var i in dbContext.Products)
			{
				total += (i.ProductCountInShopCart * i.Price);
			}


			return total;
		}
		public int ProductCount()
		{
			int ShopProductCount = 0;
			foreach (var i in dbContext.Products)
			{
				ShopProductCount += i.ProductCountInShopCart;
			}

			return ShopProductCount;
		}
		public void RemoveShopCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			session.Clear();
		}
		public static ShopCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<DBContext>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCartId);
			return new ShopCart(context) { ShopCartId = shopCartId };
		}
		public void AddToCart(Product product)
		{

			var shopCartItem = new ShopCartItem()
			{
				ShopCartId = ShopCartId,
				Product = product,
			};

			dbContext.ShopCartItems.Add(shopCartItem);
			dbContext.SaveChanges();
		}

		public List<ShopCartItem> GetShopItems()
		{
			List<ShopCartItem> shopCartItem = new List<ShopCartItem>();
			shopCartItem = dbContext.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(i => i.Product).ToList();
			return shopCartItem;
		}
	}
}
