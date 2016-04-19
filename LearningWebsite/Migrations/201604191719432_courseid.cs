namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses");
            DropIndex("dbo.CourseMaterials", new[] { "Course_Id" });
            RenameColumn(table: "dbo.CourseMaterials", name: "Course_Id", newName: "CourseId");
            AlterColumn("dbo.CourseMaterials", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseMaterials", "CourseId");
            AddForeignKey("dbo.CourseMaterials", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "CourseId", "dbo.Courses");
            DropIndex("dbo.CourseMaterials", new[] { "CourseId" });
            AlterColumn("dbo.CourseMaterials", "CourseId", c => c.Int());
            RenameColumn(table: "dbo.CourseMaterials", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.CourseMaterials", "Course_Id");
            AddForeignKey("dbo.CourseMaterials", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
