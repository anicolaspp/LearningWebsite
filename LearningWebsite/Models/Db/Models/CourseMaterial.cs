namespace LearningWebsite.Models.Db.Models
{
    public class CourseMaterial
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int PostedById { get; set; }
        public virtual User PostedBy { get; set; }
        public int Rating { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public string[] Tags { get; set; }

        //   public virtual IEnumerable<Tag> Tags { get; set; }
    }
}