using System.Collections;
using System.Collections.Generic;

namespace LearningWebsite.Models.DbModels
{
    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public virtual User PostedBy { get; set; }
        public int Rating { get; set; }
    }

    public class CourseMaterialUserRanting
    {
        public int UserId { get; set; }

        public int CourseMaterialId { get; set; }

        public virtual User RatedBy { get; set; }

        public virtual CourseMaterial CourseMaterial { get; set; }

        public int Rating { get; set; }
    }
}