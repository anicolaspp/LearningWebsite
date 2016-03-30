using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseRepository
    {
        Course GetBy(int id);
        IEnumerable<Course> GetAll();
        int Add(Course course);
    }
}