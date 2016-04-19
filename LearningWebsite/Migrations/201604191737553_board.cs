namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class board : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "DiscusionBoard_Id", "dbo.DiscusionBoards");
            DropIndex("dbo.Courses", new[] { "DiscusionBoard_Id" });
            RenameColumn(table: "dbo.Courses", name: "DiscusionBoard_Id", newName: "DiscusionBoardId");
            AlterColumn("dbo.Courses", "DiscusionBoardId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DiscusionBoardId");
            AddForeignKey("dbo.Courses", "DiscusionBoardId", "dbo.DiscusionBoards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DiscusionBoardId", "dbo.DiscusionBoards");
            DropIndex("dbo.Courses", new[] { "DiscusionBoardId" });
            AlterColumn("dbo.Courses", "DiscusionBoardId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "DiscusionBoardId", newName: "DiscusionBoard_Id");
            CreateIndex("dbo.Courses", "DiscusionBoard_Id");
            AddForeignKey("dbo.Courses", "DiscusionBoard_Id", "dbo.DiscusionBoards", "Id");
        }
    }
}
