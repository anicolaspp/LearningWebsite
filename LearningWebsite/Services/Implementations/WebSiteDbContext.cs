using System.Data.Entity;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UseConfiguration());
        }
    }
}