using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICourseMaterialService _repository;
        private readonly ITagRepository _tagRepository;

        public HomeController(ICourseMaterialService repository, ITagRepository tagRepository)
        {
            _repository = repository;
            _tagRepository = tagRepository;
        }

        public ActionResult Index()
        {
            Session["user"] = new User {Role = Role.Guest};

            return View(new HomePageViewModel
            {
                UserViewModel = new UserViewModel
                {
                    Role = Role.Guest
                }
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

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var tags = _tagRepository.GetMatchesTo(searchTerm);

            var courseMaterials = tags
                .SelectMany(tag => tag.CourseMaterials)
                .Distinct()
                .Select(cm => _repository.GetBy(cm.Id))
                .ToList();

            var user = Session["user"] as User;

            return View("Index", new HomePageViewModel
            {
                UserViewModel = new UserViewModel
                {
                    Role = user.Role,
                    UserName = user.UserName
                },
                SearchResultCourseMaterials = courseMaterials
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
    }
}