using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using Microsoft.Ajax.Utilities;

namespace LearningWebsite.Services.Implementations.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ICourseRepository _courseRepository;
        private readonly WebSiteDbContext _context;

        public UserRepository(ICourseRepository courseRepository, WebSiteDbContext context)
        {
            _courseRepository = courseRepository;
            _context = context;
        }

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
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.Posts.RemoveRange(_context.Posts.Where(post => post.PostedBy.Id == user.Id));

            var cms = _context.CourseMaterials.Where(cm => cm.PostedBy.Id == user.Id);
            _context.CourseMaterials.RemoveRange(cms);
            _context.CourseMaterialUserRantings.RemoveRange(
                _context.CourseMaterialUserRantings.Where(x => x.RatedBy.Id == user.Id));

            // need to remove the courses the user created
            _context
                .Courses
                .Where(course => course.PostedBy.Id == user.Id)
                .Select(course => course.Id)
                .ForEach(i => _courseRepository.RemoveById(i));


            _context.SaveChanges();
        }

        public User GetUserBy(int id)
        {

            var user = _context.Users.Find(id);

            if (user != null)
            {
                user.IsValid = true;
            }

            return user;

        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public bool Update(User user)
        {
            _context.Users.AddOrUpdate(user);
            return _context.SaveChanges() > 0;
        }

        public int AddPost(Post post, int userId)
        {
            User user = _context.Users.Find(userId);
            post.PostedBy = user;
            post.DiscusionBoard = _context.Boards.Find(post.DiscusionBoard.Id);
            Post postAdded = _context.Posts.Add(post);
            _context.SaveChanges();
            return postAdded.Id;
        }

        public bool RemovePostById(int id)
        {
            try
            {
                _context.Posts.Remove(_context.Posts.Find(id));
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}