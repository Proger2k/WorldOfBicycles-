using System.Collections.Generic;
using WorldOfBicycles.Data.Models;

namespace WorldOfBicycles.ViewModels
{
	public class ProfileViewModel
	{
		public IEnumerable<Rent> rents { get; set; }
	}
}
