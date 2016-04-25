using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Models.ViewModels
{
    public class UserListResult : ResultBased
    {
        public IEnumerable<User> Users { get; set; }
    }
}