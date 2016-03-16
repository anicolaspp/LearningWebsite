using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        //// GET: User
        //public ActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public ActionResult Login(UserViewModel userView)
        {
            var user = _userService.GetUserBy(userView.UserName);

            if (user.IsValid)
            {
                if (user.Password == userView.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);

                    Session["user"] = user.UserName;

                    return RedirectToAction("Index", "User", new UserViewModel {UserName = user.UserName});
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            Session["user"] = null;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Singup(UserViewModel userView)
        {
            var user = _userService.GetUserBy(userView.UserName);

            if (!user.IsValid)
            {
                User newUser = new User { UserName = userView.UserName, Password = userView.Password };

                _userService.Add(newUser);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}