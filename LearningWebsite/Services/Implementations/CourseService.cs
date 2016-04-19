using System.Collections.Generic;
using System.Linq;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
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
            return _courseRepository.Add(new Course
            {
                DiscusionBoard = new DiscusionBoard(),
                Name = model.Name
            });
        }

        public Course RemoveById(int id)
        {
            return _courseRepository.RemoveById(id);
        }
    }

    public class CourseRepository : ICourseRepository
    {
        public Course GetBy(int id)
        {
            using (var context = new WebSiteDbContext())
            {
                return context.Courses.Find(id);
            }
            //return new Course {Id = id, Name = "A Random Nico Name"};
        }

        public IEnumerable<Course> GetAll()
        {
            using (var context = new WebSiteDbContext())
            {
                var courses = context.Courses.ToList();

                return courses;
            }
        }

        public int Add(Course course)
        {
            using (var context = new WebSiteDbContext())
            {
                return context.Courses.Add(course).Id;
            }
        }

        public Course RemoveById(int id)
        {
            using (var context = new WebSiteDbContext())
            {
                return context.Courses.Remove(GetBy(id)); ;
            }
        }
    }
}