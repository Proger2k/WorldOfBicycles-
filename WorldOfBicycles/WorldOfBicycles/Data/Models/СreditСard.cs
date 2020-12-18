using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldOfBicycles.Data.Models
{
	public class СreditСard
	{
		public int id { get; set; }

		[Required]
		[StringLength(16, ErrorMessage = "Номер карты должен содержать 16 цифр", MinimumLength = 16)]
		public string CardNumber { get; set; }

		public string Validity { get; set; }

		[Required]
		[StringLength(3, ErrorMessage = "CVV должен содержать 3 цифры", MinimumLength = 3)]
		public string CVV { get; set; }
	}
}
