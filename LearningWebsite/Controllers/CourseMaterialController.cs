﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult Rate(int courseMaterialId, int rating)
        {
            var courseMaterial = _cmService.GetBy(courseMaterialId);
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
            var cmId = _cmService.Add(new CourseMaterial
            {
                Content = model.Content,
                CourseId = model.courseId,
                Title = model.Title,
                PostedById = GetLoggedUser().Id,
                Rating = model.Rating,
                Tags = model.Tags.Split(' ')
            });

            if (cmId >= 0)
            {
                return RedirectToAction("Index", "CourseDetails", new {id = model.courseId});
            }

            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult Remove(int courseMaterialId)
        {
            return View();
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
                }
            });
        }
    }

    public class CourseMaterialDetail : ResultBased
    {
        public CourseMaterialModel CourseMaterial { get; set; }
    }

    public class CourseMaterialModel
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string PostedBy { get; set; }
        public int id { get; set; }
        public string Content { get; set; }

        public int courseId { get; set; }
        public string Tags { get; set; }
    }
}