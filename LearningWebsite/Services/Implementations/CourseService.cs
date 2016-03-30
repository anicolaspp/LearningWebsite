using System.Collections.Generic;
using System.Linq;
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
            var courses = _courseRepository.GetAll();

            return courses.Where(c => c.Name.Contains(searchTerm));
        }

        public Course GetBy(int id)
        {
            return _courseRepository.GetBy(id);
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
    }
}