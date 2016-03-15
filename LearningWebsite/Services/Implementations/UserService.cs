using System.Data.Entity.Infrastructure;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserBy(string userName)
        {
            var user = _userRepository.GetUserBy(userName);

            if (user == null)
            {
                return new User();
            }
            else
            {
                return user;
            }
        }

        public User Add(User user)
        {
            var aUser = _userRepository.GetUserBy(user.UserName);

            if (aUser != null)
            {
                return null;
            }

            int id = _userRepository.Add(user);
            var newUser =_userRepository.GetUserBy(id);

            return newUser;
        }
    }
}