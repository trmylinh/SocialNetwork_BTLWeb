using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
    public class PostController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
