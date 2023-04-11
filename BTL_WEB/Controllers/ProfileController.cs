using BTL_WEB.Models;
using Microsoft.AspNetCore.Mvc;


namespace BTL_WEB.Controllers
{
    public class ProfileController : Controller
    {
		
		SocialMediaContext db = new SocialMediaContext();
        public IActionResult Index()
        {
            return View();
        }
        
		
        

    }
}
