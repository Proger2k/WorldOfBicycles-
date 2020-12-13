using System.Collections.Generic;

namespace WorldOfBicycles.Data.Models
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<Product> Products { get; set; }
		public bool IsRent { get; set; }
	}
}
