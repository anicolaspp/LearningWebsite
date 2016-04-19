﻿using System.Collections.Generic;
using System.Web.Mvc;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Filters;

namespace LearningWebsite.Controllers
{
    public class ControllerBase : Controller
    {
        public UserViewModel GetLoggedUser()
        {
            var loggedUser = Session["user"] as User;

            loggedUser = loggedUser ?? new User {Role = Role.Guest};

            return new UserViewModel
            {
                Role = loggedUser.Role,
                UserName = loggedUser.PersonName
            };
        }
    }


    public class CourseController : ControllerBase
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

            return View(new CoursesResultViewModel
            {
                UserViewModel = GetLoggedUser(),
                Courses = courses
            });
        }

  
       // [MembershipRequired(Role.Admin)]
        [HttpPost]
        public ActionResult Add(CourseModel model)
        {
            int id = _courseService.Add(model);

            if (id >= 0)
            {
                return RedirectToAction("Index");
            }

            // error creating user
            return View();
        }

     //   [MembershipRequired(Role.Admin)]
        [HttpGet]
        public ActionResult Remove(int id)
        {
            bool removed = _courseService.RemoveById(id);

            if (removed)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }

    public class CoursesResultViewModel : ResultBased
    {
        public IEnumerable<Course> Courses { get; set; }
    }
}