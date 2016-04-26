using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LearningWebsite.Models.Db.Models;
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

        private ActionResult ShowCourses(IEnumerable<Course> courses)
        {
            var models = courses.Select(c => new CourseModel
            {
                Id = c.Id,
                Name = c.Name,
                DiscusionBoard = c.DiscusionBoard,
                CourseMaterials = c.CourseMaterials,
                IsFavorite = _courseService.IsFavoriteForUser(GetLoggedUser().Id, c)
            }).ToList();

            return View("Index", new CoursesResultViewModel
            {
                UserViewModel = GetLoggedUser(),
                Courses = models
            });
        }

        // GET: Course
        public ActionResult Index()
        {
            var courses = _courseService.GetAll();

            return ShowCourses(courses);
        }
  
        [MembershipRequired(Role.Admin)]
        [HttpPost]
        public ActionResult Add(CourseModel model)
        {
            var course = _courseService.GetBy(model.Name);

            if (course != null)
            {
                return GetErrorPage($"The course {model.Name} already exists on the system. Please, use another course name.");
            }

            int id = _courseService.Add(model, GetLoggedUser().Id);

            if (id >= 0)
            {
                return RedirectToAction("Index");
            }

            // error creating user
            return GetErrorPage($"An error happened creating user {model.Name}");
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

            return GetErrorPage($"An error happened while removing the course {id}");
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

        public ActionResult GetFavorites()
        {
            var favs = _courseService.GetAll().Where(c => _courseService.IsFavoriteForUser(GetLoggedUser().Id, c));

            return ShowCourses(favs);
        }

        public override string PageName => "Course Controller";
    }
}