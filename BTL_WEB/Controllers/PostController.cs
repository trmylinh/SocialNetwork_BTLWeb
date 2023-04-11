using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using BTL_WEB.Models;
using System.Reflection.Metadata;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Runtime.CompilerServices;
using BTL_WEB.ViewModels;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;

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

        [Authentication]
        public JsonResult LikePost(string idPost, string idUser)
        {
            if (idPost == null || idUser == null)
            {
                string error = "like error";
                return new JsonResult(new { error });
            }
            Like isLiked = db.Likes.Where(x => x.UserId == int.Parse(idUser) && x.IsPostLike == true && x.TargetId == int.Parse(idPost)).FirstOrDefault();
            int amountLike;
            if(isLiked != null)
            {
                db.Likes.Remove(isLiked);
                
            }
            else
            {
                Like like = new Like();
               
                like.UserId = int.Parse(idUser);
                like.IsPostLike = true;
                like.TargetId = int.Parse(idPost);
                db.Likes.Add(like);
                
            }
            db.SaveChanges();
			amountLike = db.Likes.Where(x => x.TargetId == int.Parse(idPost)).Count();
            db.SaveChanges();
			return new JsonResult(new {isLiked, amountLike});

        }

        

		[Authentication]
		[HttpPost]
		public IActionResult PostComment(Comment comment)
		{
			if (ModelState.IsValid)
			{
				comment.UserId = (int)HttpContext.Session.GetInt32("id");
				comment.CreatedDatetime = DateTime.Now;
				db.Comments.Add(comment);
				db.SaveChanges();

				var user = db.Users.SingleOrDefault(x => x.Id == comment.UserId);

				var data = new
				{
					content = comment.TextContent,
					userImg = user.AvatarImg,
					userName = user.DisplayName,
                    creatAt = comment.CreatedDatetime.ToString()
				};

				return new JsonResult(data);
			}
			return new JsonResult(null);
		}

		[Authentication]
		public IActionResult DeletePost(string idPost, string idUser)
        {
            if(idPost == null || idUser == null || int.Parse(idUser) != (int)HttpContext.Session.GetInt32("id"))
            {
                return RedirectToAction("Index", "Home");
            }
            Post post = db.Posts.FirstOrDefault(x => x.Id == int.Parse(idPost));
            if(post == null) { 
                return RedirectToAction("Index", "Home");
            }
            List<Like> listLikePost = db.Likes.Where(x=>x.TargetId == int.Parse(idPost)).ToList();
            List<Comment> listCommentPost = db.Comments.Where(x => x.PostId == int.Parse(idPost)).ToList();
			if(listLikePost != null)
            {
                db.Likes.RemoveRange(listLikePost);
            }
			if (listCommentPost != null)
			{
				db.Comments.RemoveRange(listCommentPost);
			}
            db.Posts.Remove(post);
            db.SaveChanges();
			return RedirectToAction("Index", "Home");
		}
	}


}
