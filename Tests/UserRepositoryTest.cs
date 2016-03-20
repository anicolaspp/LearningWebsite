using FluentAssertions;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using LearningWebsite.Services.Implementations;
using Xunit;

namespace Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public void repository_should_return_no_results_when_user_doesnt_exist()
        {
            IUserRepository repository = new UserRepository();

            var user = repository.GetUserBy("missingName");

            user.Should().BeNull();
        }

        [Fact]
        public void repository_should_return_user_with_name()
        {
            IUserRepository repository = new UserRepository();

            int id = repository.Add(new User {UserName = "aName", Password = "a"});

            var user = repository.GetUserBy("aName");

            user.UserName.Should().Be("aName");
            user.Id.Should().Be(id);
            user.Role.Should().Be(Role.Member);

            repository.RemoveWith(id);
        }

        [Fact]
        public void repository_should_get_user_by_id()
        {
            IUserRepository repository = new UserRepository();

            int id = repository.Add(new User { UserName = "aName", Password = "a"});

            var user = repository.GetUserBy(id);

            user.UserName.Should().Be("aName");
            user.Id.Should().Be(id);

            repository.RemoveWith(id);
        }

        [Fact]
        public void repository_should_save_password()
        {
            IUserRepository repository = new UserRepository();

            int id = repository.Add(new User { UserName = "aName", Password = "aPassword" });

            var user = repository.GetUserBy(id);

            user.Password.Should().Be("aPassword");

            repository.RemoveWith(id);
        }
    }
    
}