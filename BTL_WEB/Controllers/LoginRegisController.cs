using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
	public class LoginRegisController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Login()
		{
			return View();
		}
	}
}
