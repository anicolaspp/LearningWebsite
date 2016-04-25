using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using LearningWebsite.Models.Db.Models;
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

        public DbSet<Tag> Tags { get; set; }

        public DbSet<CourseMaterialUserRanting> CourseMaterialUserRantings { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseUserFavorites> Favoriteses { get; set; }

        public DbSet<DiscusionBoard> Boards { get; set; }

        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CourseMaterialConfiguration());
            modelBuilder.Configurations.Add(new CourseMaterialUserRantingConfigurtion());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new CourseUserFavoritesConfiguration());
        }
    }
}