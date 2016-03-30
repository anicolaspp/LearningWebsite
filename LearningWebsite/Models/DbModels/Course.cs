using System.Collections.Generic;

namespace LearningWebsite.Models.DbModels
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<CourseMaterial> CourseMaterials { get; set; }
    }
}