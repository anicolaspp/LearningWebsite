using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using LearningWebsite.Controllers;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class UserServiceTest
    {
        private UserService _service;
        private IUserRepository _userRepository;

        public UserServiceTest()
        {
            _userRepository = Substitute.For<IUserRepository>();
            _service = new UserService(_userRepository);
        }

        [Fact]
        public void login_should_return_unknown_user_if_user_does_not_exist()
        {
            var unknownUser = _service.GetUserBy("aUserName");

            unknownUser.IsValid.Should().BeFalse();
        }

        [Fact]
        public void login_should_return_user_with_id()
        {
            _userRepository.GetUserBy("aValidUser").Returns(new User {UserName = "aValidUser", IsValid = true});

            var user = _service.GetUserBy("aValidUser");

            user.IsValid.Should().BeTrue();
            user.UserName.Should().Be("aValidUser");
        }
    }
}
