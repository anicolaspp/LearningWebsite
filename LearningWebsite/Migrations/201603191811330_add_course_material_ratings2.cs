namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_course_material_ratings2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserCourseMaterials", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserCourseMaterials", "CourseMaterial_Id", "dbo.CourseMaterials");
            DropIndex("dbo.UserCourseMaterials", new[] { "User_Id" });
            DropIndex("dbo.UserCourseMaterials", new[] { "CourseMaterial_Id" });
            CreateTable(
                "dbo.CourseMaterialUserRantings",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CourseMaterialId = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseMaterialId })
                .ForeignKey("dbo.CourseMaterials", t => t.CourseMaterialId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseMaterialId);
            
            DropTable("dbo.UserCourseMaterials");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserCourseMaterials",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        CourseMaterial_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.CourseMaterial_Id });
            
            DropForeignKey("dbo.CourseMaterialUserRantings", "UserId", "dbo.Users");
            DropForeignKey("dbo.CourseMaterialUserRantings", "CourseMaterialId", "dbo.CourseMaterials");
            DropIndex("dbo.CourseMaterialUserRantings", new[] { "CourseMaterialId" });
            DropIndex("dbo.CourseMaterialUserRantings", new[] { "UserId" });
            DropTable("dbo.CourseMaterialUserRantings");
            CreateIndex("dbo.UserCourseMaterials", "CourseMaterial_Id");
            CreateIndex("dbo.UserCourseMaterials", "User_Id");
            AddForeignKey("dbo.UserCourseMaterials", "CourseMaterial_Id", "dbo.CourseMaterials", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserCourseMaterials", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
