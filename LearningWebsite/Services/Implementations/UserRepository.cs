using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using Microsoft.Ajax.Utilities;

namespace LearningWebsite.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        private WebSiteDbContext context = new WebSiteDbContext();

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
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.Posts.RemoveRange(context.Posts.Where(post => post.PostedBy == user));
            context.CourseMaterialUserRantings.RemoveRange(
                context.CourseMaterialUserRantings.Where(x => x.RatedBy == user));

            // need to remove the courses the user created


            context.SaveChanges();
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

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        }

        public bool Update(User user)
        {
            context.Users.AddOrUpdate(user);
            return context.SaveChanges() > 0;
        }
    }
}