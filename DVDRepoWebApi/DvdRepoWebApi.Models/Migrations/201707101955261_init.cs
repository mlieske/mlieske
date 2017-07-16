namespace DvdRepoWebApi.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.DVDs",
                c => new
                    {
                        DvdId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 50),
                        RealeaseYear = c.Int(nullable: false),
                        DirectorId = c.Int(nullable: false),
                        RatingId = c.Int(nullable: false),
                        Notes = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.Directors", t => t.DirectorId)
                .ForeignKey("dbo.Ratings", t => t.RatingId)
                .Index(t => t.DirectorId)
                .Index(t => t.RatingId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDs", "RatingId", "dbo.Ratings");
            DropForeignKey("dbo.DVDs", "DirectorId", "dbo.Directors");
            DropIndex("dbo.DVDs", new[] { "RatingId" });
            DropIndex("dbo.DVDs", new[] { "DirectorId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.DVDs");
            DropTable("dbo.Directors");
        }
    }
}
