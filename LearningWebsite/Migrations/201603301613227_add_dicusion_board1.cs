namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_dicusion_board1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostedBy_Id", c => c.Int());
            CreateIndex("dbo.Posts", "PostedBy_Id");
            AddForeignKey("dbo.Posts", "PostedBy_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostedBy_Id", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "PostedBy_Id" });
            DropColumn("dbo.Posts", "PostedBy_Id");
        }
    }
}
