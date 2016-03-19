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
        private readonly ICourseMaterialService _repository;

        public SearchController(ICourseMaterialService repository)
        {
            _repository = repository;
        }

        public ActionResult Search(string searchTerm)
        {
           // var courseMaterials = _repository.GetBy( 

            return View();
        }
    }
}