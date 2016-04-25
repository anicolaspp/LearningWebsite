using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly WebSiteDbContext _context;

        public TagRepository(WebSiteDbContext context)
        {
            _context = context;
        }

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