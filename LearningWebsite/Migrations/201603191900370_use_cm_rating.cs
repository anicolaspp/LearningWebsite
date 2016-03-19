namespace LearningWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class use_cm_rating : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseMaterials", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.CourseMaterials", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CourseMaterials", "Content", c => c.String());
            AlterColumn("dbo.CourseMaterials", "Title", c => c.String());
        }
    }
}
