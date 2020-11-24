using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WorldOfBicycles.Data.Models
{
	public class User : IdentityUser
	{
		public string Name { get; set; }

		[Required]
		[StringLength(150, ErrorMessage = "Возраст не может быть меньше 18 и больше 150 лет", MinimumLength = 18)]
		public int Year { get; set; }
	}
}
