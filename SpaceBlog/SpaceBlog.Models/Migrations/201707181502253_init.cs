namespace SpaceBlog.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        PostBody = c.String(maxLength: 5000),
                        CreationDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(),
                        ImageFileName = c.String(maxLength:50),
                        PostTitle = c.String(maxLength:50),
                        UserId = c.Int(nullable: false),
                        ApprovalStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(maxLength:20),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.StaticPages",
                c => new
                    {
                        StaticPageId = c.Int(nullable: false, identity: true),
                        StaticPageTitle = c.String(maxLength:50),
                        StaticPageBody = c.String(maxLength:5000),
                        ImageFileName = c.String(maxLength:50),
                    })
                .PrimaryKey(t => t.StaticPageId);
            
            CreateTable(
                "dbo.TagPosts",
                c => new
                    {
                        Tag_TagId = c.Int(nullable: false),
                        Post_PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_TagId, t.Post_PostId })
                .ForeignKey("dbo.Tags", t => t.Tag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_PostId, cascadeDelete: true)
                .Index(t => t.Tag_TagId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagPosts", "Post_PostId", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_TagId", "dbo.Tags");
            DropIndex("dbo.TagPosts", new[] { "Post_PostId" });
            DropIndex("dbo.TagPosts", new[] { "Tag_TagId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.StaticPages");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
        }
    }
}
