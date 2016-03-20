using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseMaterialRepository
    {
        ICollection<int> GetRatingsFor(int id);
        CourseMaterial GetBy(int id);
        IEnumerable<CourseMaterial> GetCourseThatMatchName(string name);
    }
}