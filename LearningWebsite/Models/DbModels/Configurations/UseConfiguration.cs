using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class UseConfiguration : EntityTypeConfiguration<User>
    {
        public UseConfiguration()
        {
            Property(user => user.UserName)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_USERNAME", 2) {IsUnique = true}));

            Property(user => user.Password)
                .IsRequired();

            Ignore(user => user.IsValid);
        }
    }

    class CourseMaterialConfiguration : EntityTypeConfiguration<CourseMaterial>
    {
        public CourseMaterialConfiguration()
        {
            Property(material => material.Content)
                .IsRequired();

            Property(material => material.Title)
                .IsRequired();
        }
    }
}