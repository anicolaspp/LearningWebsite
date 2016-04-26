using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using WebGrease.Css.Extensions;

namespace LearningWebsite.Services.Implementations.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly WebSiteDbContext _context;

        public CourseRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public Course GetBy(int id)
        {
            return _context.Courses.Find(id);
        }

        public IEnumerable<Course> GetAll()
        {
            var courses = _context.Courses.ToList();

            return courses;
        }

        public int Add(Course course)
        {
            var entity = _context.Courses.Add(course);

            _context.SaveChanges();

            return entity.Id;
        }

        public Course RemoveById(int id)
        {
            try
            {
                var entity = _context.Courses.Remove(_context.Courses.Find(id));
                entity.CourseMaterials.ForEach(cm => _context.CourseMaterials.Remove(cm));
                _context.Favoriteses.Where(f => f.CourseId == id).ForEach(x => _context.Favoriteses.Remove(x));
                _context.Boards.Remove(_context.Boards.Find(entity.DiscusionBoardId));

                _context
                    .Posts
                    .Where(p => p.DiscusionBoard.Id == entity.DiscusionBoardId)
                    .ForEach(p => _context.Posts.Remove(p));

                _context.SaveChanges();

                return entity;
            }
            catch (EntityException)
            {
                return null;
            }
        }

        public bool IsFavoriteForUser(int userId, int courseId)
        {
            try
            {
                var relationship = _context.Favoriteses.Find(courseId, userId);

                return relationship != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool AddToFavorites(int id, int userId)
        {
            try
            {
                _context.Favoriteses.Add(new CourseUserFavorites {CourseId = id, UserId = userId});
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveFromFavorites(int id, int userId)
        {
            try
            {
                var entity = _context.Favoriteses.Find(id, userId);

                if (entity != null)
                {
                    _context.Favoriteses.Remove(entity);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Course GetBy(string name)
        {
            return _context.Courses.FirstOrDefault(c => c.Name == name);
        }
    }
}