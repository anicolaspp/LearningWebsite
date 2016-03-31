using System.Collections.Generic;
using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class ControllerBase : Controller
    {
        public UserViewModel GetLoggerUser()
        {
            var loggedUser = Session["user"] as User;

            return new UserViewModel
            {
                Role = loggedUser.Role,
                UserName = loggedUser.UserName
            };
        }
    }


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

            return View(new CoursesResultViewModel
            {
                UserViewModel = GetLoggerUser(),
                Courses = courses
            });
        }

  
        [MembershipRequired(Role.Admin)]
        [HttpPost]
        public ActionResult Add(CourseModel model)
        {
            int id = _courseService.Add(model);

            if (id >= 0)
            {
                return View(id);
            }

            // error creating user
            return View();
        }

        [MembershipRequired(Role.Admin)]
        [HttpPost]
        public ActionResult Remove(int id)
        {
            return View();
        }

       
    }

    public class CoursesResultViewModel : ResultBased
    {
        public IEnumerable<Course> Courses { get; set; }
    }

    public class CourseModel
    {
        public string Name { get; set; }
    }
}