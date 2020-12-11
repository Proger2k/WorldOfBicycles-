using System.Collections.Generic;
using WorldOfBicycles.Data.Models;

namespace WorldOfBicycles.ViewModels
{
	public class RentViewModel
	{
		public Rent Rental { get; set; }
		public IEnumerable<Product> Products { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
