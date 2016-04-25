using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.Db.Models;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class CourseMaterialUserRantingConfigurtion : EntityTypeConfiguration<CourseMaterialUserRanting>
    {
        public CourseMaterialUserRantingConfigurtion()
        {
            HasKey(cm => new {cm.UserId, cm.CourseMaterialId});
        }
    }
}