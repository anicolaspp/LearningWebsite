using System.Collections.Generic;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface IUserService
    {
        User GetUserBy(string userName);
        User Add(User user);
        IEnumerable<User> GetAll();
        User GetUserBy(int id);
        bool ToMember(User user);
        bool ToAdmin(User user);
        bool Remove(User user);
        int AddPost(Post post, int userId);
        bool RemovePostById(int id);
    }
}