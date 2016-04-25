using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LearningWebsite.Models.Db.Models;
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

        [MembershipRequired(Role.Admin)]
        public ActionResult Index()
        {
            var result = new UserListResult
            {
                UserViewModel = GetLoggedUser(),

                Users = _userService.GetAll()
            };

            return View(result);
        }

        [MembershipRequired(Role.Admin)]
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

                    var url = Request.UrlReferrer.ToString().Contains("/Account/Login")
                        ? "/Home/Index"
                        : Request.UrlReferrer?.ToString();

                    return Redirect(url);
                }
            }

            return GetErrorPage("Please, verify your credentials");
        }

        [MembershipRequired(Role.Member)]
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
                    return RedirectToAction("Index", "Home");
                }
            }

            return GetErrorPage("Verify the user name, you might have an account already!");
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Delete()
        {
            RemoveUser(GetLoggedUser().Id);

            return Logout();
        }

        [MembershipRequired(Role.Admin)]
        [HttpGet]
        public ActionResult Remove(int id)
        {
            RemoveUser(id);

            return RedirectToAction("Index");
        }

        private bool RemoveUser(int userId)
        {
            var selectedUser = _userService.GetUserBy(userId);

            if (selectedUser != null)
            {
                return _userService.Remove(selectedUser);
            }

            return false;
        }

        public override string PageName => "Account Controller";
    }
}