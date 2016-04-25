using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.Db.Models;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class CourseUserFavoritesConfiguration : EntityTypeConfiguration<CourseUserFavorites>
    {
        public CourseUserFavoritesConfiguration()
        {
            HasKey(f => new {f.CourseId, f.UserId});
        }
    }
}