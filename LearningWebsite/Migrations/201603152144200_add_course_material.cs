namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_course_material : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Rating = c.Int(nullable: false),
                        PostedById = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.PostedById)
                .Index(t => t.PostedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "PostedById", "dbo.Users");
            DropIndex("dbo.CourseMaterials", new[] { "PostedById" });
            DropTable("dbo.CourseMaterials");
        }
    }
}
