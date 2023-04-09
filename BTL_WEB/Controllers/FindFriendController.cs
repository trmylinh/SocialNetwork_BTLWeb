using BTL_WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTL_WEB.Controllers
{
    public class FindFriendController : Controller
    {
        private readonly SocialMediaContext _db;
        public FindFriendController(SocialMediaContext db)
        {
            _db = db;
        }
        //[HttpGet]
        public IActionResult Index()
        {
            // Hiển thị list user không phải bạn của user hiện tại
            // Status = 0 == Accepted
            // Status = 1 == Pending
            var currentUserId = HttpContext.Session.GetInt32("id");
            var listUser =
                (from user in _db.Users
                 where user.Id != currentUserId && !(
                    from u1 in _db.Users
                    join f1 in _db.FriendRequests on u1.Id equals f1.UserId
                    where u1.Id == currentUserId && f1.Status == 0
                    select f1.FriendId).Union(
                         from u2 in _db.Users
                         join f2 in _db.FriendRequests on u2.Id equals f2.FriendId
                         where u2.Id == currentUserId && f2.Status == 0
                         select f2.UserId
                    ).Contains(user.Id) select user).ToList();
            return View(listUser);
        }
        // Send request
        // Cancel request
        // Accept request
    }
}