using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models;

namespace LearningWebsite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userView)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Singup(UserViewModel userView)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}