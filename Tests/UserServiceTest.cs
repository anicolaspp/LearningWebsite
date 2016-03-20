using System.Collections.Generic;
using FluentAssertions;
using LearningWebsite.Controllers;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Implementations;
using NSubstitute;
using Xunit;

namespace Tests
{
    public class UserServiceTest
    {
        private readonly UserService _service;
        private readonly IUserRepository _userRepository;

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

        [Fact]
        public void add_should_not_add_existing_user()
        {
            _userRepository.GetUserBy("aUser").Returns(new User {UserName = "aUser"});

            var user = _service.Add(new User {UserName = "aUser"});

            user.Should().BeNull();
        }

        [Fact]
        public void add_should_add_only_new_users()
        {
            var aUser = new User {UserName = "aUser"};
            
            _userRepository.GetUserBy("aUser").Returns(x => null);
            _userRepository.Add(aUser).Returns(1);
            _userRepository.GetUserBy(1).Returns(new User {UserName = "aUser", Id = 1});

            var user = _service.Add(aUser);

            user.UserName.Should().Be("aUser");
            user.Id.Should().Be(1);
        }
    }
}
