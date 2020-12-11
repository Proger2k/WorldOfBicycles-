using Microsoft.AspNetCore.Mvc;

namespace WorldOfBicycles.Controllers
{
	public class ProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
