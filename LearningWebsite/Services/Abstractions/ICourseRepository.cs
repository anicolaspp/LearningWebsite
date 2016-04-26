using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseRepository
    {
        Course GetBy(int id);
        IEnumerable<Course> GetAll();
        int Add(Course course);
        Course RemoveById(int id);
        bool IsFavoriteForUser(int userId, int courseId);
        bool AddToFavorites(int id, int userId);
        bool RemoveFromFavorites(int id, int userId);
        Course GetBy(string name);
    }
}