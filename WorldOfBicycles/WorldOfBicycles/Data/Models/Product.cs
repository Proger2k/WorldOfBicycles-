using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldOfBicycles.Data.Models
{
	public class Product
	{
		[BindNever]
		public int Id { get; set; }

		[Display(Name = "Введите Url-адрес картинки")]
		public string Img { get; set; }

		[Display(Name = "Введите название товара")]
		public string Name { get; set; }

		[Display(Name = "Введите цену товара")]
		public int Price { get; set; }

		[Display(Name = "Введите количество товара")]
		public int Count { get; set; }

		[Display(Name = "Введите скидку на товар")]
		public int? Discount { get; set; }

		[Display(Name = "Описание товара")]
		public string Description { get; set; }

		[Display(Name = "Выберите категорию")]
		public string Cat { get; set; }
		
		[BindNever]
		public int ProductCountInShopCart { get; set; }

		[BindNever]
		public int CategoryId { get; set; }

		[BindNever]
		public Category Category { get; set; }
	}
}
