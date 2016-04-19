namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_posted_by : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "PostedBy_Id", c => c.Int());
            CreateIndex("dbo.Courses", "PostedBy_Id");
            AddForeignKey("dbo.Courses", "PostedBy_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "PostedBy_Id", "dbo.Users");
            DropIndex("dbo.Courses", new[] { "PostedBy_Id" });
            DropColumn("dbo.Courses", "PostedBy_Id");
        }
    }
}
