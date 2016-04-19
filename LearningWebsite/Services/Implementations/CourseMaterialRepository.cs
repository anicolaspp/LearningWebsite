using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseMaterialRepository : ICourseMaterialRepository
    {
        private WebSiteDbContext context = new WebSiteDbContext();

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
            var cm = context.CourseMaterials.Find(id);

            return cm;
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