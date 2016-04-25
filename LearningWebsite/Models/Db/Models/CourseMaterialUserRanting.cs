namespace LearningWebsite.Models.Db.Models
{
    public class CourseMaterialUserRanting
    {
        public int UserId { get; set; }

        public int CourseMaterialId { get; set; }

        public virtual User RatedBy { get; set; }

        public virtual CourseMaterial CourseMaterial { get; set; }

        public int Rating { get; set; }
    }

    public class CourseUserFavorites
    {
        public int CourseId { get; set; }
        public int UserId { get; set; }
    }
}