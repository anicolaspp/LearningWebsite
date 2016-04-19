using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using WebGrease.Css.Extensions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private WebSiteDbContext context = new WebSiteDbContext();

        public Course GetBy(int id)
        {
     //       using (var context = new WebSiteDbContext())
            {
                return context.Courses.Find(id);
            }
        }

        public IEnumerable<Course> GetAll()
        {
        //    using (var context = new WebSiteDbContext())
            {
                var courses = context.Courses.ToList();

                return courses;
            }
        }

        public int Add(Course course)
        {
         //   using (var context = new WebSiteDbContext())
            {
                var entity = context.Courses.Add(course);

                context.SaveChanges();

                return entity.Id;
            }
        }

        public Course RemoveById(int id)
        {
            try
            {
             //   using (var context = new WebSiteDbContext())
                {
                    var entity = context.Courses.Remove(context.Courses.Find(id));
                    entity.CourseMaterials.ForEach(cm => context.CourseMaterials.Remove(cm));
                    context.Favoriteses.Where(f => f.CourseId == id).ForEach(x => context.Favoriteses.Remove(x));
                    context.Boards.Remove(context.Boards.Find(entity.DiscusionBoardId));

                    context.SaveChanges();

                    return entity;
                }
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
  //              using (var context = new WebSiteDbContext())
                {
                    var relationship = context.Favoriteses.Find(courseId, userId);

                    return relationship != null;
                }
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
                context.Favoriteses.Add(new CourseUserFavorites {CourseId = id, UserId = userId});
                context.SaveChanges();

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
                var entity = context.Favoriteses.Find(id, userId);

                if (entity != null)
                {
                    context.Favoriteses.Remove(entity);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}