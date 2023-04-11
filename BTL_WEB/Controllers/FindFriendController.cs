using BTL_WEB.Models;
using BTL_WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTL_WEB.Controllers
{
    public class FindFriendController : Controller
    {
        private readonly SocialMediaContext _db;
        public FindFriendController(SocialMediaContext db)
        {
            _db = db;
        }
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
                         where u2.Id == currentUserId
                         select f2.UserId
                    ).Contains(user.Id) select user).ToList();
            return View(listUser);
        }
        public IActionResult GoToFriendList()
        {
            var currentUserId = HttpContext.Session.GetInt32("id");
            // Hiển thị danh sách bạn bè
            var query = (from f in _db.FriendRequests
                         where currentUserId == f.UserId && f.Status == 0
                         select f.FriendId).Union(
                            from f1 in _db.FriendRequests
                            where currentUserId == f1.FriendId && f1.Status == 0
                            select f1.UserId
                         ).ToList();
            var users = _db.Users.Where(u => query.Contains(u.Id)).ToList();
            return View(users);
        }
        // Send request
        [HttpPost]
        public IActionResult SendFriendRequest(int userId)
        {
            var currentUserId = HttpContext.Session.GetInt32("id");
            if (_db.FriendRequests.Where(f => (f.UserId == currentUserId && f.FriendId == userId) && f.Status == 1).FirstOrDefault() == null)
            {
                FriendRequest friendRequest = new FriendRequest();
                friendRequest.UserId = (int)currentUserId;
                friendRequest.FriendId = userId;
                friendRequest.Status = 1;
                friendRequest.SentTime = DateTime.Now;
                _db.FriendRequests.Add(friendRequest);
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "FindFriend");
        }
        // Decline request
        [HttpDelete]
        public IActionResult DeclineFriendRequest(int userId)
        {
            var currentUserId = HttpContext.Session.GetInt32("id");
            var friendRequest = _db.FriendRequests.Where(f => f.FriendId == currentUserId && f.UserId == userId && f.Status == 1).FirstOrDefault();
            if (friendRequest != null)
            {
                _db.FriendRequests.Remove(friendRequest);
            }
            return RedirectToAction("Index", "Home");
        }
        // Accept request
        [HttpPost]
        public IActionResult AcceptFriendRequest(int userId)
        {
            var currentUserId = HttpContext.Session.GetInt32("id");
            var friendRequest = _db.FriendRequests.Where(f => f.FriendId == currentUserId && f.UserId == userId && f.Status == 1).FirstOrDefault();
            // Chuyển status thành 0
            if(friendRequest != null)
            {
                friendRequest.Status = 0;
                _db.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        //public IActionResult ShowFriendRequest()
        //{
        //    var currentUserId = HttpContext.Session.GetInt32("id");
        //    var query = (from f in _db.FriendRequests
        //                 where currentUserId == f.UserId && f.Status == 1
        //                 select f.FriendId).Union(
        //                    from f1 in _db.FriendRequests
        //                    where currentUserId == f1.FriendId && f1.Status == 1
        //                    select f1.UserId
        //                 ).ToList();
        //    var users = _db.Users.Where(u => query.Contains(u.Id)).ToList();
        //    return View("~/View/Shared/_Layout.cshtml", users);
        //}
    }
}