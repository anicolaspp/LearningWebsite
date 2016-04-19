using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

       // [MembershipRequired(Role.Admin)]
        public ActionResult Index()
        {
            var result = new UserListResult
            {
                UserViewModel = GetLoggedUser(),

                Users = _userService.GetAll()
            };

            return View(result);
        }

        [HttpGet]
        public ActionResult Promote(int id)
        {
            var selectedUser = _userService.GetUserBy(id);

            if (selectedUser.Role == Role.Admin)
            {
                _userService.ToMember(selectedUser);
            }
            else
            {
                _userService.ToAdmin(selectedUser);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Login(UserViewModel userView)
        {
            var user = _userService.GetUserBy(userView.UserName);

            if (user.IsValid)
            {
                if (user.Password == userView.Password)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    Session["user"] = user;
                }
            }

            return Redirect(Request.UrlReferrer.ToString());
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
                User newUser = new User
                {
                    UserName = userView.UserName,
                    Password = userView.Password,
                    PersonName = userView.PersonName
                };

                var nUser = _userService.Add(newUser);

                if (nUser != null)
                {
                    Session["user"] = nUser;
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {


            return RedirectToAction("Index");
        }
    }

    public class UserListResult : ResultBased
    {
        public IEnumerable<User> Users { get; set; }
    }
}