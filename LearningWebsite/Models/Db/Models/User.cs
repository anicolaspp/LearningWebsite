using System.Collections.Generic;

namespace LearningWebsite.Models.Db.Models
{
    public class User
    {
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PersonName { get; set; }

        public virtual Role Role { get; set; }

        public virtual IList<CourseMaterial> CourseMaterials { get; set; }
    }


    public enum Role
    {
        Guest = 0,
        Member = 1,
        Admin = 2   
    }
}