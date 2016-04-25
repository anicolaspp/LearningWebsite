using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class CourseMaterialController : ControllerBase
    {
        private readonly ICourseMaterialService _cmService;

        public CourseMaterialController(ICourseMaterialService cmService)
        {
            _cmService = cmService;
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Rate(RateModel model)
        {
            bool result = _cmService.Rate(model.courseMaterialId, model.Rating, GetLoggedUser().Id);

            if (result)
            {
                return RedirectToAction("Index", "CourseDetails", new {id = model.courseId});
            }


            return GetErrorPage("An error happened during the rating operation");
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Tag(TagRequestModel model)
        {
            var result = _cmService.UpdateTagsFor(model.courseMaterialId, model.Tags);

            if (result)
            {
                return RedirectToAction("Index", "CourseDetails", new {id = model.courseId});
            }

            return GetErrorPage("An error happened while updating the tags");
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Add(CourseMaterialModel model)
        {
            var cmId = _cmService.Add(new CourseMaterial
            {
                Content = model.Content,
                CourseId = model.courseId,
                Title = model.Title,
                PostedById = GetLoggedUser().Id,
                Rating = model.Rating,
                Tags = model.Tags?.Split(' ')??new string[]{}
            });

            if (cmId >= 0)
            {
                return RedirectToAction("Index", "CourseDetails", new {id = model.courseId});
            }

            return GetErrorPage("An error happened adding course material");
        }

        [MembershipRequired(Role.Member)]
        [HttpGet]
        public ActionResult Remove(int courseMaterialId, int courseId)
        {
            bool result = _cmService.Remove(courseMaterialId);

            if (result)
            {
                return RedirectToAction("Index", "CourseDetails", new {id = courseId});
            }

            return GetErrorPage("An error happened removing course material");
        }

        public ActionResult Details(int id)
        {
            var cm = _cmService.GetBy(id);

            return View(new CourseMaterialDetail
            {
                UserViewModel = GetLoggedUser(),
                CourseMaterial = new CourseMaterialModel
                {
                    Title = cm.Title,
                    Rating = cm.Rating,
                    PostedBy = cm.PostedBy.PersonName,
                    id = cm.Id,
                    Content = cm.Content,
                    courseId = cm.Course.Id
                }
            });
        }

        public ActionResult GoToCourse(int id)
        {
            return RedirectToAction("Index", "CourseDetails", new {id});
        }

        public override string PageName => "Course Material Details";
    }
}