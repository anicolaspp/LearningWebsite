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
}