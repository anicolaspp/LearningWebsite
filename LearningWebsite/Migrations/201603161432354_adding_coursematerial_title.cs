namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding_coursematerial_title : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CourseMaterials", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CourseMaterials", "Title");
        }
    }
}
