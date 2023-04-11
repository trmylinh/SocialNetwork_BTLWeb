using BTL_WEB.Models;
using BTL_WEB.Models.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace BTL_WEB.Controllers
{
	public class EditProfileController : Controller
	{
		private IHostingEnvironment _env;
		public EditProfileController(IHostingEnvironment _environment)
		{
			_env = _environment;

		}
		SocialMediaContext db = new SocialMediaContext();
        [Route("Index")]
        [HttpGet]
        public IActionResult Index(int? userID)
        {
            try
            {
                //ViewBag.id = new SelectList(db.Users.ToList(), "id", "users");
                var user = db.Users.Find(userID);
                return View(user);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return View("Error", ex);
            }
        }

        [Route("Index")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Index(User user, IFormFile img)
        {
            try
            {
                if (true)
                {
                    User userChange = db.Users.FirstOrDefault(x => x.Id == user.Id);
                    userChange.Username = user.Username;
                    userChange.DisplayName = user.DisplayName;
                    userChange.Email = user.Email;
                    userChange.Password = user.Password;
                    userChange.Gender = user.Gender;
                    userChange.Birthday = user.Birthday;
					
					db.SaveChanges();
                    HttpContext.Session.SetString("username", userChange.Username.ToString());
                    HttpContext.Session.SetString("fullname", userChange.DisplayName.ToString());
                    HttpContext.Session.SetString("email", userChange.Email.ToString());
                    HttpContext.Session.SetString("password", userChange.Password.ToString());
                    HttpContext.Session.SetInt32("gender", Int32.Parse(userChange.Gender.ToString()));
                    HttpContext.Session.SetString("birthday", userChange.Birthday.ToString());
					HttpContext.Session.SetString("avatar", userChange.AvatarImg.ToString());
					// Gọi trực tiếp action "Index" của controller "Profile" với thông tin đã cập nhật
					return View("~/Views/Profile/Index.cshtml");
                }

                return View(user);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                return View("Error", ex);
            }
        }

		

	}
}
