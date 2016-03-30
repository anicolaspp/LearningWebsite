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
            return GetAll().Where(c => c.Name.Contains(searchTerm));
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
    }

    public class CourseRepository : ICourseRepository
    {
        public Course GetBy(int id)
        {
            return new Course {Id = id, Name = "A Random Nico Name"};
        }

        public IEnumerable<Course> GetAll()
        {
            return new []
            {
                new Course {Id = 1, Name = "one"},
                new Course {Id = 2, Name = "two"}
            };
        }

        public int Add(Course course)
        {
            return 1;
        }
    }
}