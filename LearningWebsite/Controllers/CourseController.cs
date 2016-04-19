using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = _courseService.GetAll();

            var models = courses.Select(c => new CourseModel
            {
                Id = c.Id,
                Name = c.Name,
                DiscusionBoard = c.DiscusionBoard,
                CourseMaterials = c.CourseMaterials,
                IsFavorite = _courseService.IsFavoriteForUser(GetLoggedUser().Id, c)
            }).ToList();

            return View(new CoursesResultViewModel
            {
                UserViewModel = GetLoggedUser(),
                Courses = models
            });
        }

  
        [MembershipRequired(Role.Admin)]
        [HttpPost]
        public ActionResult Add(CourseModel model)
        {
            int id = _courseService.Add(model);

            if (id >= 0)
            {
                return RedirectToAction("Index");
            }

            // error creating user
            return View();
        }

        [MembershipRequired(Role.Admin)]
        [HttpGet]
        public ActionResult Remove(int id)
        {
            bool removed = _courseService.RemoveById(id);

            if (removed)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpGet]
        public ActionResult AddToFavorites(int id)
        {
            var course = _courseService.GetBy(id);

            bool isFavorite = _courseService.IsFavoriteForUser(GetLoggedUser().Id, course);

            if (isFavorite)
            {
                _courseService.RemoveFromFavorites(course, GetLoggedUser().Id);
            }
            else
            {
                _courseService.AddToFavorites(course, GetLoggedUser().Id);
            }

            return RedirectToAction("Index");
        }
    }

    public class CoursesResultViewModel : ResultBased
    {
        public IEnumerable<CourseModel> Courses { get; set; }
    }
}