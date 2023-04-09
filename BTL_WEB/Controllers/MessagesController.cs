using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
	public class MessagesController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
