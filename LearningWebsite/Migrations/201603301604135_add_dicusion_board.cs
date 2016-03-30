namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_dicusion_board : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DiscusionBoards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        Content = c.String(),
                        DiscusionBoard_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DiscusionBoards", t => t.DiscusionBoard_Id)
                .Index(t => t.DiscusionBoard_Id);
            
            AddColumn("dbo.Courses", "DiscusionBoard_Id", c => c.Int());
            CreateIndex("dbo.Courses", "DiscusionBoard_Id");
            AddForeignKey("dbo.Courses", "DiscusionBoard_Id", "dbo.DiscusionBoards", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DiscusionBoard_Id", "dbo.DiscusionBoards");
            DropForeignKey("dbo.Posts", "DiscusionBoard_Id", "dbo.DiscusionBoards");
            DropIndex("dbo.Posts", new[] { "DiscusionBoard_Id" });
            DropIndex("dbo.Courses", new[] { "DiscusionBoard_Id" });
            DropColumn("dbo.Courses", "DiscusionBoard_Id");
            DropTable("dbo.Posts");
            DropTable("dbo.DiscusionBoards");
        }
    }
}
