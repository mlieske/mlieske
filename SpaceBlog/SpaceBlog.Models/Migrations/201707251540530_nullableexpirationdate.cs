namespace SpaceBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableexpirationdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "ExpirationDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "ExpirationDate", c => c.DateTime(nullable: false));
        }
    }
}
