namespace LearningWebsite.Models.ViewModels
{
    public class ErrorModel : ResultBased
    {
        public string PageName { get; set; }

        public string ErrorMessage { get; set; }
    }
}