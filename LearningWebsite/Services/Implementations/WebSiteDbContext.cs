using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.DbModels;
using LearningWebsite.Models.DbModels.Configurations;

namespace LearningWebsite.Services.Implementations
{
    public class WebSiteDbContext : DbContext
    {
        public WebSiteDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<CourseMaterial> CourseMaterials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CourseMaterialConfiguration());

            modelBuilder.Entity<CourseMaterialUserRanting>()
                .HasKey(cm => new {cm.UserId, cm.CourseMaterialId});

            
        }
    }
}