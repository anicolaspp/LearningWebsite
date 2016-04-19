namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discussion_board_timestamp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiscusionBoards", "TimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiscusionBoards", "TimeStamp");
        }
    }
}
