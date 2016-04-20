using System.Collections.Generic;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseService
    {
        IEnumerable<Course> GetMatcherFor(string searchTerm);

        Course GetBy(int id);
        IEnumerable<Course> GetAll();
        int Add(CourseModel model, int userId);

        bool RemoveById(int id);
        bool IsFavoriteForUser(int userName, Course course);
        bool RemoveFromFavorites(Course course, int userId);
        bool AddToFavorites(Course course, int userId);
    }
}