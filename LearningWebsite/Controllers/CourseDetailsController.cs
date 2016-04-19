 using System.Web.Mvc;
 using LearningWebsite.Models.ViewModels;
 using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseDetailsController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var course = _courseService.GetBy(id);

            if (course != null)
            {
                return View(new CourseResultViewModel
                {
                    UserViewModel = GetLoggedUser(),
                    Course = new CourseModel
                    {
                        Name = course.Name,
                    }
                });
            }

            //Not Found
            return View();
        }
    }

    public class CourseResultViewModel : ResultBased
    {
        public CourseModel Course { get; set; }
    }
    
}