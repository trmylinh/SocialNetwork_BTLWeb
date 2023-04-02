using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models;
using System.Reflection.Metadata;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Runtime.CompilerServices;

namespace BTL_WEB.Controllers
{
    public class PostController : Controller
    {
		private IHostingEnvironment _env;
		SocialMediaContext db = new SocialMediaContext();

        public PostController(IHostingEnvironment _environment)
        {
            _env = _environment;

        }

        [Authentication]
        public IActionResult YourPost()
        {
            if(HttpContext.Session.GetInt32("id") != null)
            {
                int currentId = (int)HttpContext.Session.GetInt32("id");
                List<Post> currentPost = db.Posts.Where(x=>x.UserId == currentId).OrderByDescending(x=>x.CreatedDatetime).ToList();
                return View(currentPost);
            }
            return View();                                                                                                                      
        }

        [HttpPost]
        public IActionResult CreatePost(string content, List<IFormFile> images)
        {

            Post post = new Post();
            post.UserId = (int)HttpContext.Session.GetInt32("id");
            post.TextContent = content;
            post.CreatedDatetime = DateTime.Now;
			db.Posts.Add(post);
			db.SaveChanges();
            foreach (var image in images)
            {
                if (image != null)
                {
                    string fileUser = HttpContext.Session.GetString("username").ToString();
                    string serverMapPath = Path.Combine(_env.WebRootPath, "ImageTitle");
                    string serverMapPathFile = Path.Combine(serverMapPath, image.FileName);
                    Directory.CreateDirectory(serverMapPath);
                    using (var stream = new FileStream(serverMapPathFile, FileMode.Create))
                    {
                        image.CopyTo(stream);
                    }
                    string filepath = "https://localhost:7070/" + "ImageTitle/" + image.FileName;
                    var postId = post.Id;
                    Medium media = new Medium();
                    media.PostId = postId;
                    media.MediaFile = filepath;
                    media.MediaType = image.GetType().Name.ToString();
                    db.Media.Add(media);
                    post.Media.Add(media);
                }
            }
            db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
    }
}
