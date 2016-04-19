namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class favorite_courses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseUserFavorites",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.UserId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CourseUserFavorites");
        }
    }
}
