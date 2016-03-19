namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tags_to_cms : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagCourseMaterials",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        CourseMaterial_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.CourseMaterial_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseMaterials", t => t.CourseMaterial_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.CourseMaterial_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagCourseMaterials", "CourseMaterial_Id", "dbo.CourseMaterials");
            DropForeignKey("dbo.TagCourseMaterials", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TagCourseMaterials", new[] { "CourseMaterial_Id" });
            DropIndex("dbo.TagCourseMaterials", new[] { "Tag_Id" });
            DropTable("dbo.TagCourseMaterials");
            DropTable("dbo.Tags");
        }
    }
}
