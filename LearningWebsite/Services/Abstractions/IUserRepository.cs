using System.Collections.Generic;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface IUserRepository
    {
        User GetUserBy(string userName);
        int Add(User user);
        void RemoveWith(int id);
        User GetUserBy(int id);
        IEnumerable<User> GetAll();
        bool Update(User user);
    }
}