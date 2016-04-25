namespace LearningWebsite.Models.ViewModels
{
    public class CourseMaterialModel
    {
        public string Title { get; set; }
        public int Rating { get; set; }
        public string PostedBy { get; set; }
        public int id { get; set; }
        public string Content { get; set; }

        public int courseId { get; set; }
        public string Tags { get; set; }
    }
}