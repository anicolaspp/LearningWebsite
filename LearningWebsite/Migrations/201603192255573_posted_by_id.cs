namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posted_by_id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseMaterials", "PostedById", "dbo.Users");
            DropIndex("dbo.CourseMaterials", new[] { "PostedById" });
            //RenameColumn(table: "dbo.CourseMaterials", name: "PostedBy_Id", newName: "PostedById");
            AlterColumn("dbo.CourseMaterials", "PostedById", c => c.Int(nullable: false));
            CreateIndex("dbo.CourseMaterials", "PostedById");
            AddForeignKey("dbo.CourseMaterials", "PostedById", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CourseMaterials", "PostedById", "dbo.Users");
            DropIndex("dbo.CourseMaterials", new[] { "PostedById" });
            AlterColumn("dbo.CourseMaterials", "PostedById", c => c.Int());
            RenameColumn(table: "dbo.CourseMaterials", name: "PostedById", newName: "PostedBy_Id");
            CreateIndex("dbo.CourseMaterials", "PostedBy_Id");
            AddForeignKey("dbo.CourseMaterials", "PostedBy_Id", "dbo.Users", "Id");
        }
    }
}
