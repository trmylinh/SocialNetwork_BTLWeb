using BTL_WEB.Models;
using BTL_WEB.Models.Authentication;
using BTL_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BTL_WEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

		SocialMediaContext db = new SocialMediaContext();
		public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // phan quyen tat ca cac duong dan vao page thi them [Authentication]
        [Authentication] 
        // home/index 
		// Show all posts tren trang home/index
        public IActionResult Index()
        {
			if(HttpContext.Session.GetInt32("id") != null)
			{
				//	int currentId = (int)HttpContext.Session.GetInt32("id");
				//	List<Post> currentPost = db.Posts.Where(x => x.UserId == currentId).OrderByDescending(x => x.CreatedDatetime).ToList();
				List<Post> allPosts = db.Posts.OrderByDescending(x => x.CreatedDatetime).ToList();
				List<PostDetailViewModel> postDetailVM = new List<PostDetailViewModel>();
				foreach (Post item in allPosts)
				{
					var listImg = db.Media.Where(x => x.PostId == item.Id).ToList();
					postDetailVM.Add(new PostDetailViewModel
					{
						post = item,
						listmedia = listImg
					});
				}
				return View(postDetailVM);
			}
			return View();
		}


       
		[Authentication]
		public IActionResult YourPost()
		{
			if (HttpContext.Session.GetInt32("id") != null)
			{
				int currentId = (int)HttpContext.Session.GetInt32("id");
				List<Post> currentPost = db.Posts.Where(x => x.UserId == currentId).OrderByDescending(x => x.CreatedDatetime).ToList();
				List<string> media = new List<string>();
                foreach (var item in currentPost)
                {
					var postId_media  = db.Media.Where(x => x.PostId == item.Id).ToList();
					
				
                }
              
				return View(currentPost);
			}
			
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