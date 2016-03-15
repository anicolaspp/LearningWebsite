namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ignore_isValid_user : DbMigration
    {
        public override void Up()
        {
            Sql("delete from dbo.Users");
            DropColumn("dbo.Users", "IsValid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsValid", c => c.Boolean(nullable: false));
        }
    }
}
