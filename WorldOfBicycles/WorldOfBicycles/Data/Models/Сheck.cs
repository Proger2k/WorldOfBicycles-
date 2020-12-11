using Microsoft.OData.Edm;

namespace WorldOfBicycles.Data.Models
{
	public class Сheck
	{
		public int Id { get; set; }
		public Rent Rent { get; set; }
		public string Date { get; set; }
	}
}
