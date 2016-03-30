using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseRepository;

        public CourseController(ICourseService courseRepository)
        {
            _courseRepository = courseRepository;
        }

        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        {
            var course = _courseRepository.GetBy(id);

            if (course != null)
            {
                return View(course);
            }

            //Not Found
            return View();
        }
    }
}