using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Models.ViewModels
{
    public class HomePageViewModel
    {
        public UserViewModel UserViewModel { get; set; }

        public IEnumerable<CourseMaterial> SearchResultCourseMaterials { get; set; }
        public IEnumerable<Course> SearchResultCourses { get; set; }
    }
}