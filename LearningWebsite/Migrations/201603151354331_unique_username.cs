namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique_username : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            //CreateIndex("dbo.Users", "UserName", unique: true, name: "IX_USERNAME");
        }
        
        public override void Down()
        {
            //DropIndex("dbo.Users", "IX_USERNAME");
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
