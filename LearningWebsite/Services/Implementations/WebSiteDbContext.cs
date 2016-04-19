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

        public DbSet<Tag> Tags { get; set; }

        public DbSet<CourseMaterialUserRanting> CourseMaterialUserRantings { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseUserFavorites> Favoriteses { get; set; }

        public DbSet<DiscusionBoard> Boards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CourseMaterialConfiguration());

            modelBuilder.Entity<CourseMaterialUserRanting>()
                .HasKey(cm => new {cm.UserId, cm.CourseMaterialId});

            modelBuilder.Entity<Tag>()
                .HasMany(t => t.CourseMaterials)
                .WithMany();

            modelBuilder.Entity<CourseUserFavorites>()
                .HasKey(f => new {f.CourseId, f.UserId});


            //.HasMany<>(tag => tag.CourseMaterials)
            //.WithMany(material => material.Tags);
        }
    }
}