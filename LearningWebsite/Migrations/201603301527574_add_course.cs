namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_course : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CourseMaterials", "Course_Id", c => c.Int());
            CreateIndex("dbo.CourseMaterials", "Course_Id");
            AddForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseMaterials", new[] { "Course_Id" });
            DropColumn("dbo.CourseMaterials", "Course_Id");
            DropTable("dbo.Courses");
        }
    }
}
