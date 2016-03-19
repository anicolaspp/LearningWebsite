using System.Linq;
using LearningWebsite.Models.DbModels;

namespace LearningWebsite.Services.Implementations
{
    public class CourseMaterialService
    {
        private readonly ICourseMaterialRepository _courseMaterialRepository;

        public CourseMaterialService(ICourseMaterialRepository courseMaterialRepository)
        {
            _courseMaterialRepository = courseMaterialRepository;
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
                cm.Rating = (int)ratings.Average(x => x.Rating);
            }

            return cm;
        }
    }
}