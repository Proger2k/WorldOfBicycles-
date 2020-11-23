using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.OData.Edm;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldOfBicycles.Data.Models
{
	public class Rent
	{
		[BindNever]
		public int Id { get; set; }

		[Display(Name = "Выберите категорию")]
		public Category Category { get; set; }

		[Display(Name = "Введите количество велосипедов для аренды")]
		public int ProductCount { get; set; }

		[NotMapped]
		[Display(Name = "Введите дату и время аренды")]
		public Date Date { get; set; }

		[Display(Name = "Введите продолжительность аренды")]
		public int Duration { get; set; }
		public User User { get; set; }
	}
}
