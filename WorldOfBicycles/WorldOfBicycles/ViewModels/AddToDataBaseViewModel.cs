﻿using WorldOfBicycles.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorldOfBicycles.ViewModels
{
	public class AddToDataBaseViewModel
	{
		public Product Product { get; set; }
		public Category Category { get; set; }
		public IEnumerable<Category> Categories { get; set; }
	}
}
