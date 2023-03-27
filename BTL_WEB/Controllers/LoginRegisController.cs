using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models;
using MessagePack.Resolvers;

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

		[HttpGet]
		public IActionResult Login()
		{
			if(HttpContext.Session.GetString("email") == null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index","Home");
			}
			
		}

		[HttpPost]
		public IActionResult Login(User user)
		{
			if(HttpContext.Session.GetString("email")== null)
			{
				var u = db.Users.Where(x=>x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
				if(u != null)
				{
					HttpContext.Session.SetString("email", u.Email.ToString());
					HttpContext.Session.SetString("fullname", u.DisplayName.ToString());
					
					var username = u.Username;
                    return RedirectToAction("Index", "Home");
                }
			}

			return View();
		}


		public IActionResult Logout()
		{
			HttpContext.Session.Clear();
			HttpContext.Session.Remove("email");

			return RedirectToAction("Login", "LoginRegis");
		}
	}
}
