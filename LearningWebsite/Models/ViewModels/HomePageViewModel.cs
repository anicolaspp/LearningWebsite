using System.Collections.Generic;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Models.ViewModels
{
    public class HomePageViewModel : ResultBased
    {
        public IEnumerable<CourseMaterial> SearchResultCourseMaterials { get; set; }
        public IEnumerable<Course> SearchResultCourses { get; set; }
    }


    public class ResultBased
    {
        public UserViewModel UserViewModel { get; set; }
    }
}