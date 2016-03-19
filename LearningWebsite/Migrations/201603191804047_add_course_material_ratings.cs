namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_course_material_ratings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCourseMaterials",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        CourseMaterial_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.CourseMaterial_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseMaterials", t => t.CourseMaterial_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.CourseMaterial_Id);
            
            DropColumn("dbo.CourseMaterials", "Rating");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CourseMaterials", "Rating", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserCourseMaterials", "CourseMaterial_Id", "dbo.CourseMaterials");
            DropForeignKey("dbo.UserCourseMaterials", "User_Id", "dbo.Users");
            DropIndex("dbo.UserCourseMaterials", new[] { "CourseMaterial_Id" });
            DropIndex("dbo.UserCourseMaterials", new[] { "User_Id" });
            DropTable("dbo.UserCourseMaterials");
        }
    }
}
