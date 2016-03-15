using System.Collections;
using System.Collections.Generic;

namespace LearningWebsite.Models.DbModels
{
    public class User
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string PersonName { get; set; }

        public virtual IList<CourseMaterial> CourseMaterials { get; set; }
    }

    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Content { get; set; }
        public virtual User PostedBy { get; set; }

        public int Rating { get; set; }
    }
}