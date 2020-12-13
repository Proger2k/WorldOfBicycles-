using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WorldOfBicycles.Data.Models
{
	public class Rent
	{
		[BindNever]
		public int Id { get; set; }

		[Display(Name = "Имя")]
		public string FirstName { get; set; }

		[Display(Name = "Фамилия")]
		public string Surname { get; set; }

		[Display(Name = "Введите дату и время аренды")]
		public string Date { get; set; }

		[Display(Name = "Введите продолжительность аренды")]
		public string Duration { get; set; }
		public СreditСard CreditCard { get; set; }
		public int CredirCardId { get; set; }
		public int ProductCount { get; set; }
		public string Code { get; set; }
		public User User { get; set; }

		[BindNever]
		public int ProductId { get; set; }

		[BindNever]
		public Product Product { get; set; }

		public int Sum { get; set; }
	}
}
