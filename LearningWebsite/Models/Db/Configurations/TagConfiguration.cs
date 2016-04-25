using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.Db.Models;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            HasMany(t => t.CourseMaterials)
                .WithMany();
        } 
    }
}