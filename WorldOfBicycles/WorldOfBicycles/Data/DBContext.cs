using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldOfBicycles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.Data
{
	public class DBContext : IdentityDbContext<User>
	{
		public DBContext(DbContextOptions<DBContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShopCartItem> ShopCartItems { get; set; }
	}
}
