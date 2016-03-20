using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        public ICollection<int> GetRatingsFor(int id)
        {
            using (var context = new WebSiteDbContext())
            {
                return context
                    .CourseMaterialUserRantings
                    .Where(ranting => ranting.CourseMaterialId == id)
                    .Select(cm => cm.Rating).ToList();
            }
        }

        public CourseMaterial GetBy(int id)
        {
            using (var context = new WebSiteDbContext())
            {
                return context.CourseMaterials.Find(id);
            }
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