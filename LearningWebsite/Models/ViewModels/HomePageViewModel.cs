using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Models.ViewModels
{
    public class HomePageViewModel : ResultBased
    {
        public IEnumerable<CourseMaterial> SearchResultCourseMaterials { get; set; } = new List<CourseMaterial>();
        public IEnumerable<Course> SearchResultCourses { get; set; } = new List<Course>();
    }


    public class ResultBased
    {
        public UserViewModel UserViewModel { get; set; }
    }
}