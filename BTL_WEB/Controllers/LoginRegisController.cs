using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models;

namespace BTL_WEB.Controllers
{
	public class LoginRegisController : Controller
	{
		SocialMediaContext db = new SocialMediaContext();
		
		// index -> register
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
