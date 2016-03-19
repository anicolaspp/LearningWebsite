using System.Data.Entity.ModelConfiguration;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class CourseMaterialConfiguration : EntityTypeConfiguration<CourseMaterial>
    {
        public CourseMaterialConfiguration()
        {
            Property(material => material.Content)
                .IsRequired();

            Property(material => material.Title)
                .IsRequired();

            Ignore(cm => cm.Rating);
        }
    }
}