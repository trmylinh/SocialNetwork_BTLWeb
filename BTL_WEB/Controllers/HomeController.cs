using BTL_WEB.Models;
using BTL_WEB.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // phan quyen tat ca cac duong dan vao page thi them [Authentication]
        [Authentication] 
        // home/index
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}