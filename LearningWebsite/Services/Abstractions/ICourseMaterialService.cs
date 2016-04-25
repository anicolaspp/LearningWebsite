using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseMaterialService
    {
        CourseMaterial GetBy(int id);
        IEnumerable<CourseMaterial> GetMatchesFor(string searchTerm);
        int Add(CourseMaterial courseMaterial);
        bool UpdateTagsFor(int courseMaterialId, string tags);
        bool Rate(int courseMaterialId, int rating, int userId);
        bool Remove(int courseMaterialId);
    }
}