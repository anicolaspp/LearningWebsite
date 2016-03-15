using System.ComponentModel.DataAnnotations;

namespace LearningWebsite.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
