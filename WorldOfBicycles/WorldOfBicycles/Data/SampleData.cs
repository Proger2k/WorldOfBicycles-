using WorldOfBicycles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
						Name = "Рубашка",
						Description = "Красная",
						Count = 10,
						Price = 250,
						Discount = 500,
						Img = "/img/SampleData/1.jpg",
						Category = Categories["Рубашки"]
					},
					new Product()
					{
						Name = "Рубашка",
						Description = "Светлая",
						Price = 150,
						Count = 10,
						Discount = 250,
						Img = "/img/SampleData/2.jpg",
						Category = Categories["Рубашки"]
					},
					new Product()
					{
						Name = "Рубашка",
						Description = "Темная",
						Price = 300,
						Count = 10,
						Discount = 500,
						Img = "/img/SampleData/3.jpg",
						Category = Categories["Рубашки"]
					},
					new Product()
					{
						Name = "Кофта",
						Description = "Темная",
						Price = 150,
						Count = 10,
						Discount = 300,
						Img = "/img/SampleData/4.jpg",
						Category = Categories["Кофты"]
					},
					new Product()
					{
						Name = "Кофта",
						Description = "Комуфляж",
						Price = 300,
						Count = 10,
						Img = "/img/SampleData/5.jpg",
						Category = Categories["Кофты"]
					},
					new Product()
					{
						Name = "Мужской спортивный костюм",
						Description = "Спорт",
						Price = 500,
						Count = 10,
						Img = "/img/SampleData/6.jpg",
						Category = Categories["Спортивная одежда"]
					},
					new Product()
					{
						Name = "Спотривный костюм",
						Description = "Для бега",
						Price = 450,
						Count = 10,
						Img = "/img/SampleData/7.jpg",
						Category = Categories["Спортивная одежда"]
					},
					new Product()
					{
						Name = "Спортивная кофта",
						Description = "Спорт",
						Price = 300,
						Count = 10,
						Img = "/img/SampleData/8.jpg",
						Category = Categories["Спортивная одежда"]
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
						Name = "Рубашки"
					},
					new Category()
					{
						Name = "Спортивная одежда"
					},
					new Category()
					{
						Name = "Кофты"
					}
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
