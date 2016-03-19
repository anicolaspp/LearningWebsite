using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    
    public class HomePageViewModel
    {
        public UserViewModel UserViewModel { get; set; }

        public IEnumerable<CourseMaterial> SearchResultCourseMaterials { get; set; }
    }
}
