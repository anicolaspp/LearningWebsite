using System.Collections.Generic;
using System.Linq;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations
{
    public class CourseMaterialService : ICourseMaterialService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;
        private readonly ITagRepository _tagRepository;

        public CourseMaterialService(ICourseMaterialRepository courseMaterialRepository, ITagRepository tagRepository)
        {
            _courseMaterialRepository = courseMaterialRepository;
            _tagRepository = tagRepository;
        }

        public CourseMaterial GetBy(int id)
        {
            var cm = _courseMaterialRepository.GetBy(id);

            if (cm == null)
            {
                return null;
            }

            var ratings = _courseMaterialRepository.GetRatingsFor(cm.Id);

            if (ratings.Count > 0)
            {
                cm.Rating = (int) ratings.Average();
            }

            return cm;
        }

        public IEnumerable<CourseMaterial> GetMatchesFor(string searchTerm)
        {
            var tags = _tagRepository.GetMatchesTo(searchTerm);

            return tags
                .SelectMany(tag => tag.CourseMaterials)
                .Distinct()
                .ToList();
        }
    }
}