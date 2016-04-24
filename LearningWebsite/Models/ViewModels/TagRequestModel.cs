namespace LearningWebsite.Models.ViewModels
{
    public class TagRequestModel
    {
        public int courseId { get; set; }
        public int courseMaterialId { get; set; }

        public string Tags { get; set; }
    }
}