using System.Collections.Generic;
using LearningWebsite.Controllers;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.ViewModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseService
    {
        IEnumerable<Course> GetMatcherFor(string searchTerm);

        Course GetBy(int id);

        Course GetBy(string name);
        IEnumerable<Course> GetAll();
        int Add(CourseModel model, int userId);

        bool RemoveById(int id);
        bool IsFavoriteForUser(int userName, Course course);
        bool RemoveFromFavorites(Course course, int userId);
        bool AddToFavorites(Course course, int userId);
        
    }
}