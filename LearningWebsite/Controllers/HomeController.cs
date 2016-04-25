using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class HomeController : ControllerBase
    {
        private readonly ICourseMaterialService _cmService;
        private readonly ICourseService _courseService;

        public HomeController(ICourseMaterialService cmService, ICourseService courseService)
        {
            _cmService = cmService;
            _courseService = courseService;
        }

        public ActionResult Index()
        {
            if (Session["user"] == null)
            {
                Session["user"] = new User {Role = Role.Guest};
            }

            return View(new HomePageViewModel
            {
                UserViewModel = GetLoggedUser()
            });
        }

        [HttpPost]
        public ActionResult Index(HomePageViewModel dataModel)
        {
            var user = Session["user"] as User;

            dataModel.UserViewModel = new UserViewModel
            {
                Role = user.Role,
                UserName = user.UserName
            };

            return View(dataModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            return Search("");
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var cmResult = _cmService.GetMatchesFor(searchTerm).ToList();
            cmResult.Sort((x, y) => -1*x.Rating.CompareTo(y.Rating));

            var crResult = _courseService.GetMatcherFor(searchTerm);

            return View("Index", new HomePageViewModel
            {
                UserViewModel = GetLoggedUser(),
                SearchResultCourseMaterials = cmResult,
                SearchResultCourses = crResult
            });
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
        public override string PageName => "Home Page Controller";
    }
}