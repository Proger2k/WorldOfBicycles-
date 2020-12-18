using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldOfBicycles.Data.Models;

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
		public DbSet<Rent> Rents { get; set; }
		public DbSet<Сheck> Checks { get; set; }
		public DbSet<СreditСard> СreditСards { get; set; }
	}
}
