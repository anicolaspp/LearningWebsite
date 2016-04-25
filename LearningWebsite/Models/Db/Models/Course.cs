using System.Collections.Generic;

namespace LearningWebsite.Models.Db.Models
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<CourseMaterial> CourseMaterials { get; set; } = new List<CourseMaterial>();

        public int DiscusionBoardId { get; set; }

        public virtual DiscusionBoard DiscusionBoard { get; set; }

        public virtual User PostedBy { get; set; }
    }
}