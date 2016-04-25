using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Models.ViewModels
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<CourseMaterial> CourseMaterials { get; set; }

        public DiscusionBoard DiscusionBoard { get; set; }

        public bool IsFavorite { get; set; }
    }
}