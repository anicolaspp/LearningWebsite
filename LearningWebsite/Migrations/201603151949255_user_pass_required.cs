namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_pass_required : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }
    }
}
