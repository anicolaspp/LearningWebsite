using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Services.Implementations;

namespace LearningWebsite.Controllers
{
    public class SearchController : Controller
    {
        private readonly ICourseMaterialRepository _repository;

        public SearchController(ICourseMaterialRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Search(string searchTerm)
        {
            var courses = _repository.GetCourseThatMatchName(searchTerm);

            return View(courses);
        }
    }
}