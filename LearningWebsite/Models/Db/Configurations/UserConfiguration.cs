using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.Db.Models;

namespace LearningWebsite.Models.DbModels.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
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
}