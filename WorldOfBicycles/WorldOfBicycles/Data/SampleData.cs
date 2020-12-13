using WorldOfBicycles.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace WorldOfBicycles.Data
{
	public class SampleData
	{
		public static void Initialize(DBContext db)
		{
			if(!db.Products.Any())
			{
				db.Products.AddRange(
					new Product()
					{
						Name = "Comanche Strada",
						Count = 10,
						Price = 250,
						Discount = 500,
						Img = "/img/SampleData/1.jpg",
						Category = Categories["Спортивные велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Hurricane",
						Price = 150,
						Count = 10,
						Discount = 250,
						Img = "/img/SampleData/2.jpg",
						Category = Categories["Спортивные велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Prairie",
						Price = 300,
						Count = 10,
						Discount = 500,
						Img = "/img/SampleData/3.jpg",
						Category = Categories["Спортивные велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Niagara",
						Price = 150,
						Count = 10,
						Discount = 300,
						Img = "/img/SampleData/1г.jpg",
						Category = Categories["Горные велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Orinoco",
						Price = 300,
						Count = 10,
						Img = "/img/SampleData/2г.jpg",
						Category = Categories["Горные велосипеды"]
					},
					new Product()
					{
						Name = "Ranger Magnum",
						Price = 500,
						Count = 10,
						Img = "/img/SampleData/3г.jpg",
						Category = Categories["Горные велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Holiday",
						Price = 450,
						Count = 10,
						Img = "/img/SampleData/1город.jpg",
						Category = Categories["Городские велосипеды"]
					},
					new Product()
					{
						Name = "Comanche Solo",
						Price = 300,
						Count = 10,
						Img = "/img/SampleData/2город.jpg",
						Category = Categories["Городские велосипеды"]
					}
				);  
			}
			db.SaveChanges();
		}
		public static Dictionary<string, Category> Category;
		public static Dictionary<string, Category> Categories
		{
			get
			{
				Category[] categories = new Category[]
				{
					new Category()
					{
						Name = "Спортивные велосипеды",
						IsRent = true,
					},
					new Category()
					{
						Name = "Горные велосипеды",
						IsRent = true,
					},
					new Category()
					{
						Name = "Городские велосипеды",
						IsRent = true,
					},
				};

				Category = new Dictionary<string, Category>();
				foreach(var i in categories)
				{
					Category.Add(i.Name,i);
				}
				return Category;
			}
		}
	}
}
