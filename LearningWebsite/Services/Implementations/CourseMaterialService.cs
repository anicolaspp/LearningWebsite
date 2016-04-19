using System;
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

        private int GetRating(int id)
        {
            var ratings = _courseMaterialRepository.GetRatingsFor(id);

            if (ratings.Any())
            {
                return Math.Min(1, (int) ratings.Average());
            }
            else
            {
                return 1;
            }
        }

        public CourseMaterial GetBy(int id)
        {
            var cm = _courseMaterialRepository.GetBy(id);

            if (cm == null)
            {
                return null;
            }

            cm.Rating = GetRating(cm.Id);

            return cm;
        }

        public IEnumerable<CourseMaterial> GetMatchesFor(string searchTerm)
        {
            var tags = _tagRepository.GetMatchesTo(searchTerm);

            var courseMaterials = tags
                .SelectMany(tag => tag.CourseMaterials)
                .Distinct()
                .ToList();

            courseMaterials.ForEach(cm => cm.Rating = GetRating(cm.Id));

            return courseMaterials;
        }
    }
}