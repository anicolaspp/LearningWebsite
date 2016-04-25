using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using LearningWebsite.Models.Db.Models;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Services.Abstractions;

namespace LearningWebsite.Services.Implementations.Services
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
                return (int) ratings.Average();
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
            cm.Tags = _courseMaterialRepository.GetTagsFor(id);

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

        public int Add(CourseMaterial courseMaterial)
        {
            var result = _courseMaterialRepository.Add(courseMaterial);

            return result;
        }

        public bool UpdateTagsFor(int courseMaterialId, string tags)
        {
            var ts = tags?.Split(' ').Where(tag => !string.IsNullOrEmpty(tag)) ?? new string[] { };


          //  var ts = tags.Split(' ').Where(tag => !string.IsNullOrEmpty(tag));
          

            return _courseMaterialRepository.UpdateTagsFor(courseMaterialId, ts);
        }

        public bool Rate(int courseMaterialId, int rating, int userId)
        {
            return _courseMaterialRepository.AddRating(courseMaterialId, rating, userId);
        }

        public bool Remove(int courseMaterialId)
        {
            return _courseMaterialRepository.Remove(courseMaterialId);
        }
    }
}