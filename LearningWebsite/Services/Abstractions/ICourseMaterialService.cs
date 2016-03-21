using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseMaterialService
    {
        CourseMaterial GetBy(int id);
        IEnumerable<CourseMaterial> GetMatchesFor(string searchTerm);
    }
}