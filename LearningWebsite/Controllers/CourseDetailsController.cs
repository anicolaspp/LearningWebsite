﻿ using System;
 using System.Collections.Generic;
 using System.Linq;
 using System.Web.Mvc;
 using LearningWebsite.Models.DbModels;
 using LearningWebsite.Models.ViewModels;
 using LearningWebsite.Services.Abstractions;
 using LearningWebsite.Services.Filters;
 using Ninject.Infrastructure.Language;

namespace LearningWebsite.Controllers
{
    public class CourseDetailsController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;
        private readonly ICourseMaterialService _cmService;

        public CourseDetailsController(ICourseService courseService, IUserService userService, ICourseMaterialService cmService)
        {
            _courseService = courseService;
            _userService = userService;
            _cmService = cmService;
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
                        CourseMaterials = new List<CourseMaterial>(course.CourseMaterials.Select(cm => _cmService.GetBy(cm.Id))),
                        DiscusionBoard = course.DiscusionBoard,
                        Id = course.Id,
                        IsFavorite = _courseService.IsFavoriteForUser(GetLoggedUser().Id, course)
                    }
                });
            }

            //Not Found
            return View();
        }

        [MembershipRequired(Role.Member)]
        [HttpPost]
        public ActionResult AddPost(PostViewModel post)
        {
            var couse = _courseService.GetBy(post.courseId);

            int result = _userService.AddPost(new Post
            {
                Content = post.Content,
                DiscusionBoard = couse.DiscusionBoard
            }, GetLoggedUser().Id);

            if (result >= 0)
            {
                return RedirectToAction("Index", new {id = couse.Id});
            }

            return View();
        }

        [MembershipRequired(Role.Admin)]
        [HttpGet]
        public ActionResult RemovePost(int postId)
        {
            var course = _courseService
                .GetAll()
                .Where(c =>
                {
                    var posts = c.DiscusionBoard.Posts;

                    if (posts.Any(post => post.Id == postId))
                    {
                        return true;
                    }

                    return false;
                }).FirstOrDefault();

            if (course == null)
            {
                return View();
            }
                

            bool result = _userService.RemovePostById(postId);

            if (result)
            {
                return RedirectToAction("Index", new {id = course.Id});
            }

            return View();
        }


    }

    public class CourseResultViewModel : ResultBased
    {
        public CourseModel Course { get; set; }
    }

    public class PostViewModel
    {
        public int courseId { get; set; }

        public string Content { get; set; }
    }
}