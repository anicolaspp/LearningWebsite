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
            return RedirectToAction("Index", "Home");
        }
    }

    public interface IUserService
    {
        User GetUserBy(string userName);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserBy(string userName)
        {
            var user = _userRepository.GetUserBy(userName);

            if (user == null)
            {
                return new User();
            }
            else
            {
                return user;
            }
        }
    }

    public interface IUserRepository
    {
        User GetUserBy(string userName);
    }

    public class User
    {
        public bool IsValid { get; set; }
        public string UserName { get; set; }
    }
}