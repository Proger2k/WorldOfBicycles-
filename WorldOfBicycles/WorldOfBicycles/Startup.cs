using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorldOfBicycles.Data;
using WorldOfBicycles.Data.Models;

namespace WorldOfBicycles
{
	public class Startup
	{
		IConfiguration Configuration;
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public void ConfigureServices(IServiceCollection services)
		{
			var connection = Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));



			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShopCart.GetCart(sp));

			services.AddIdentity<User, IdentityRole>(opts => {
				opts.Password.RequiredLength = 3;   
				opts.Password.RequireNonAlphanumeric = false;   
				opts.Password.RequireLowercase = false; 
				opts.Password.RequireUppercase = false; 
				opts.Password.RequireDigit = false; 
			})
				.AddEntityFrameworkStores<DBContext>();

			services.AddSignalR();
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseRouting();
			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();

			app.UseAuthentication();    
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Chat}/{action=Index}");
				endpoints.MapHub<ChatHub>("/chat");
			});

			using var scope = app.ApplicationServices.CreateScope();
			DBContext context = scope.ServiceProvider.GetRequiredService<DBContext>();

		}
	}
}
