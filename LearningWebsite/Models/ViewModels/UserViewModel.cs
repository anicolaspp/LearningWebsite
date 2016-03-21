using System.ComponentModel.DataAnnotations;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
