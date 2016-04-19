using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlTypes;
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

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserBy(int id)
        {
            return _userRepository.GetUserBy(id);
        }

        public bool ToMember(User user)
        {
            user.Role = Role.Member;
            return _userRepository.Update(user);
        }

        public bool ToAdmin(User user)
        {
            user.Role = Role.Admin;
            return _userRepository.Update(user);
        }

        public bool Remove(User user)
        {
             _userRepository.RemoveWith(user.Id);

            return true;
        }
    }
}