using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class TagRepository : ITagRepository
    {
        private readonly WebSiteDbContext _context = new WebSiteDbContext();

        public IEnumerable<Tag> GetMatchesTo(string nameToMatch)
        {
            var tags = _context
                .Tags
                .Where(t => t.Name.Contains(nameToMatch))
                .Include(t => t.CourseMaterials)
                .ToList();

            return tags;
        }
    }
}