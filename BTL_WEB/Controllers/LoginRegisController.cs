﻿using BTL_WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BTL_WEB.Controllers
{
    public class LoginRegisController : Controller
    {
        SocialMediaContext db = new SocialMediaContext();
        private static readonly Regex EmailRegex = new Regex(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$", RegexOptions.Compiled);
        // index là register

        //REGISTER 
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            //ModelState.AddModelError("Email", "");
            if (db.Users.FirstOrDefault(x => x.Email == user.Email) != null)
            {
                if (db.Users.FirstOrDefault(x => x.Username == user.Username) != null)
                {
                    //TempData["Error"] = "Email";
                    ModelState.AddModelError("Username", "Username error");

                    //return View(user);
                }
                //TempData["Error"] = "Email";
                ModelState.AddModelError("Email", "Email error");

                return View(user);
            }


            //if (!ModelState.IsValid) { return View(user); }

            //if (ModelState.IsValid)
            //{
            var u = db.Users.Where(x => x.Email == user.Email).FirstOrDefault();
            bool isEmail = EmailRegex.IsMatch(user.Email);

            if (user.Password == "" || user.DisplayName == "" || user.Email == "" || !isEmail)
            {
                return View();
            }


            //if (u != null)
            //{
            //	return View();
            //}
            //else
            //{
            User newUser = new User();
            newUser.Email = user.Email;
            newUser.DisplayName = user.DisplayName;
            newUser.Username = user.Username;
            newUser.Password = user.Password;
            db.Users.Add(newUser);
            db.SaveChanges();
            return RedirectToAction("Login", "LoginRegis");
            //}
            //}
            //return View();



        }

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("email") == null)
            {
                var u = db.Users.Where(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("email", u.Email.ToString());
                    HttpContext.Session.SetString("fullname", u.DisplayName.ToString());

                    var username = u.Username;
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("email");

            return RedirectToAction("Login", "LoginRegis");
        }


    }
}
