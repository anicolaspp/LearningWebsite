using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class CourseMaterialController : Controller
    {
        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Rate(int courseMaterialId, int rating)
        {
            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Tag(TagRequestModel model)
        {
            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Add(CourseMaterialModel model)
        {
            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Remove(int courseMaterialId)
        {
            return View();
        }

        public ActionResult Details(int courseMaterialId)
        {
            return View();
        }
    }

    public class CourseMaterialModel
    {
    }
}