using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Abstractions
{
    public interface IUserService
    {
        User GetUserBy(string userName);
        User Add(User user);
    }
}