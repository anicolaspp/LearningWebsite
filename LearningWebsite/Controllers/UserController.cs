using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userView)
        {
            var user = _userService.GetUserBy(userView.UserName);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Singup(UserViewModel userView)
        {
            var user = _userService.GetUserBy(userView.UserName);

            if (!user.IsValid)
            {
                User newUser = new User {UserName = userView.UserName};

                _userService.Add(newUser);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}