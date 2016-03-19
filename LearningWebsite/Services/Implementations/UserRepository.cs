using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        public User GetUserBy(string userName)
        {
            using (var dbContext = new WebSiteDbContext())
            {
                var user = dbContext.Users.FirstOrDefault(u => u.UserName == userName);

                if (user != null)
                {
                    user.IsValid = true;
                }

                return user;
            }
        }

        public int Add(User user)
        {
            using (var dbContext = new WebSiteDbContext())
            {
                user.Role = Role.Member;

                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                return user.Id;
            }
        }

        public void RemoveWith(int id)
        {
            using (var dbContext = new WebSiteDbContext())
            {
                dbContext.Users.Remove(dbContext.Users.Find(id));

                dbContext.SaveChanges();
            }
        }

        public User GetUserBy(int id)
        {
            using (var dbContext = new WebSiteDbContext())
            {
                var user = dbContext.Users.Find(id);

                if (user != null)
                {
                    user.IsValid = true;
                }

                return user;
            }
        }
    }

    public interface ICourseMaterialRepository
    {
        ICollection<CourseMaterialUserRanting> GetRatingsFor(int id);
        CourseMaterial GetBy(int id);
        IEnumerable<CourseMaterial> GetCourseThatMatchName(string name);
    }

    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        public ICollection<CourseMaterialUserRanting> GetRatingsFor(int id)
        {
            throw new System.NotImplementedException();
        }

        public CourseMaterial GetBy(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CourseMaterial> GetCourseThatMatchName(string name)
        {
            using (var context = new WebSiteDbContext())
            {
                var courseMaterialThatMatches = context.CourseMaterials.Where(material => material.Content == name);

                return courseMaterialThatMatches;
            }
        }
    }
}