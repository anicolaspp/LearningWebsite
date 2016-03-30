 using System.Web.Mvc;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseDetailsController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public ActionResult Get(int id)
        {
            var course = _courseService.GetBy(id);

            if (course != null)
            {
                return View(course);
            }

            //Not Found
            return View();
        }
    }
}