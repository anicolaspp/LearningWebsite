namespace LearningWebsite.Models.DbModels
{
    public class CourseMaterialUserRanting
    {
        public int UserId { get; set; }

        public int CourseMaterialId { get; set; }

        public virtual User RatedBy { get; set; }

        public virtual CourseMaterial CourseMaterial { get; set; }

        public int Rating { get; set; }
    }
}