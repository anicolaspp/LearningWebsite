using System;
using System.Collections.Generic;
using System.Linq;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;
using WebGrease.Css.Extensions;

namespace LearningWebsite.Services.Implementations.Repositories
{
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        private readonly WebSiteDbContext _context;

        public CourseMaterialRepository(WebSiteDbContext context)
        {
            _context = context;
        }

        public ICollection<int> GetRatingsFor(int id)
        {
            _context.ChangeTracker.DetectChanges();

            return _context
                .CourseMaterialUserRantings
                .Where(ranting => ranting.CourseMaterialId == id)
                .Select(cm => cm.Rating).ToList();
        }

        public CourseMaterial GetBy(int id)
        {
            var cm = _context.CourseMaterials.Find(id);

            return cm;
        }

        public IEnumerable<CourseMaterial> GetCourseThatMatchName(string name)
        {
            var courseMaterialThatMatches = _context.CourseMaterials.Where(material => material.Content == name);

            return courseMaterialThatMatches;
        }

        public int Add(CourseMaterial courseMaterial)
        {
            try
            {
                _context.CourseMaterials.Add(courseMaterial);

                _context.SaveChanges();

                UpdateTagsFor(courseMaterial.Id, courseMaterial.Tags);

                return courseMaterial.Id;
            }

            catch 
            {
                return -1;
            }
        }

        public bool UpdateTagsFor(int cmId, IEnumerable<string> tags)
        {
            _context.ChangeTracker.DetectChanges();

            var ts = _context.Tags.Where(t => t.CourseMaterials.Select(cm => cm.Id).Contains(cmId));
         

            var courseMaterial = GetBy(cmId);
            
            var newTags = tags.Where(tag =>
            {
                var ex = ts.Select(t => t.Name);

                return ex.Contains(tag) == false;
            });

            var newToDb = newTags.Where(t => !_context.Tags.Select(x => x.Name).Contains(t));

            newToDb.ForEach(tag =>
            {
                _context.Tags.Add(new Tag { Name = tag, CourseMaterials = new List<CourseMaterial> { courseMaterial } });
            });

            var existingInDb = newTags.Where(t => _context.Tags.Select(x => x.Name).Contains(t));

            existingInDb.ForEach(tag =>
            {
                var t = _context.Tags.First(x => x.Name == tag);
                t.CourseMaterials.Add(courseMaterial);
            });

            var tagsToRemove = ts.Where(t => !tags.Contains(t.Name)).ToList();

            tagsToRemove.ForEach(t =>
            {
                if (t.CourseMaterials.Count == 1)
                {
                    _context.Tags.Remove(t);
                }
                else
                {
                    t.CourseMaterials.Remove(courseMaterial);
                }
            });

            _context.SaveChanges();

            return true;
        }

        public string[] GetTagsFor(int id)
        {
            var tags = _context
                .Tags
                .Where(t => t.CourseMaterials.Select(cm => cm.Id)
                    .Contains(id))
                .Select(t => t.Name);

            return tags.ToArray();
        }

        public bool AddRating(int courseMaterialId, int rating, int userId)
        {
            var userRating = _context
                .CourseMaterialUserRantings
                .Find(userId, courseMaterialId);

            if (userRating == null)
            {
                _context.CourseMaterialUserRantings.Add(new CourseMaterialUserRanting
                {
                    UserId = userId,
                    CourseMaterialId = courseMaterialId,
                    Rating = rating
                });
            }
            else
            {
                userRating.Rating = rating;
            }

            _context.SaveChanges();

            return true;
        }

        public bool Remove(int courseMaterialId)
        {
            try
            {
                var cm = _context.CourseMaterials.Find(courseMaterialId);
                var ratings = _context.CourseMaterialUserRantings.Where(r => r.CourseMaterial.Id == cm.Id);
                var tags = _context.Tags.Where(t => t.CourseMaterials.Select(c=>c.Id).Contains(cm.Id)).ToList();

                tags.ForEach(t =>
                {
                    if (t.CourseMaterials.Count == 1)
                    {
                        _context.Tags.Remove(t);
                    }
                    else
                    {
                        t.CourseMaterials.Remove(cm);
                    }
                });

                _context.CourseMaterials.Remove(cm);
                _context.CourseMaterialUserRantings.RemoveRange(ratings);

                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}