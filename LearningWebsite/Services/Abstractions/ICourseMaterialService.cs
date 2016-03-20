using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface ICourseMaterialService
    {
        CourseMaterial GetBy(int id);
    }
}