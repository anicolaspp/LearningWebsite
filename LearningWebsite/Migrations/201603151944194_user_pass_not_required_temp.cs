namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_pass_not_required_temp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
        }
    }
}
