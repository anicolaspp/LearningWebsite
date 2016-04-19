﻿using System.Collections.Generic;
using System.Linq;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;

        public CourseService(ICourseRepository courseRepository, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<Course> GetMatcherFor(string searchTerm)
        {
            return GetAll().Where(c => c.Name.ToLower().Contains(searchTerm));
        }

        public Course GetBy(int id)
        {
            return _courseRepository.GetBy(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public int Add(CourseModel model)
        {
            if (GetAll().Any(c => c.Name.ToLower() == model.Name.ToLower()))
            {
                return -1;
            }

            return _courseRepository.Add(new Course
            {
                DiscusionBoard = new DiscusionBoard(),
                Name = model.Name
            });
        }

        public bool RemoveById(int id)
        {
            var entity = _courseRepository.RemoveById(id);

            return entity != null;
        }

        public bool IsFavoriteForUser(int id, Course course)
        {
            var user = _userRepository.GetUserBy(id);

            if (user == null)
            {
                return false;
            }

            bool result = _courseRepository.IsFavoriteForUser(user.Id, course.Id);

            return result;
        }

        public bool RemoveFromFavorites(Course course, int userId)
        {
            return _courseRepository.RemoveFromFavorites(course.Id, userId);
        }

        public bool AddToFavorites(Course course, int userId)
        {
            return _courseRepository.AddToFavorites(course.Id, userId);
        }
    }
}