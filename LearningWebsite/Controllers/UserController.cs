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
using Microsoft.AspNet.Identity;

namespace LearningWebsite.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index(UserViewModel userView)
        {
            if (Session["user"] != null)
            {
                return View(userView);
            }
            return RedirectToAction("Login");
        }

       
    }
}