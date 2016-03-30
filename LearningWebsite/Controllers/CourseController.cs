using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class CourseController : Controller
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

            return View(courses);
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

    public class CourseModel
    {
        public string Name { get; set; }
    }
}