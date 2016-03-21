using System.Collections.Generic;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseService : ICourseService
    {
        public IEnumerable<Course> GetMatcherFor(string searchTerm)
        {
            return new[] {new Course()};
        }
    }
}