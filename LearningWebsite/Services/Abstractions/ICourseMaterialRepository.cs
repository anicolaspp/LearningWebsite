using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseMaterialRepository
    {
        ICollection<int> GetRatingsFor(int id);
        CourseMaterial GetBy(int id);
        IEnumerable<CourseMaterial> GetCourseThatMatchName(string name);
        int Add(CourseMaterial courseMaterial);

        bool UpdateTagsFor(int cmId, IEnumerable<string> tags);
        string[] GetTagsFor(int id);
        bool AddRating(int courseMaterialId, int rating, int userId);
        bool Remove(int courseMaterialId);
    }
}