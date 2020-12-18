using WorldOfBicycles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.ViewModels
{
	public class ShopViewModel
	{
		public IEnumerable<Product> Products { get; set; }
	}
}
