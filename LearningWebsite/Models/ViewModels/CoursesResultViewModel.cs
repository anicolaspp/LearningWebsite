using System.Collections.Generic;

namespace LearningWebsite.Models.ViewModels
{
    public class CoursesResultViewModel : ResultBased
    {
        public IEnumerable<CourseModel> Courses { get; set; }
    }
}