namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_person_name : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PersonName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "PersonName");
        }
    }
}
