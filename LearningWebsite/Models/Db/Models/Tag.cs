using System.Collections.Generic;

namespace LearningWebsite.Models.Db.Models
{
    public class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CourseMaterial> CourseMaterials { get; set; }
    }
}