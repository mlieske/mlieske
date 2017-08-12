namespace SpaceBlog.Models.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaceBlog.Models.DbContextEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaceBlog.Models.DbContextEntities context)
        {
            //if (!System.Diagnostics.Debugger.IsAttached)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Posts.AddOrUpdate(
                p => p.PostTitle,
                new Post
                {
                    //PostId = 1,
                    PostBody = "Space... The final Frontier. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    CreationDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder5.jpg",
                    PostTitle = "Star Trek vs. Star Wars",
                    UserId = "1",
                    ApprovalStatus = true,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    //PostId = 2,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    PostTitle = "Changing How We Look At Space Exploration",
                    CreationDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder2.jpg",

                    UserId = "1",
                    ApprovalStatus = true,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    //PostId = 3,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    CreationDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder3.jpg",
                    PostTitle = "Are We Alone?",
                    UserId = "1",
                    ApprovalStatus = false,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    //PostId = 4,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    CreationDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder4.jpg",
                    PostTitle = "Supermassive Blackholes Exist, Or Do They?",
                    UserId = "1",
                    ApprovalStatus = true,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    //PostId = 5,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    CreationDate = DateTime.Now,
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder5.jpg",
                    PostTitle = "The Interplanetary Travel Network",
                    UserId = "1",
                    ApprovalStatus = false,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    //PostId = 6,
                    PostBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                    CreationDate = DateTime.Now, 
                    ExpirationDate = DateTime.ParseExact("12/1/2016", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    ImageFileName = "/Website IMAGES/placeholder2.jpg",
                    PostTitle = "The Universe: Mansplained",
                    UserId = "1",
                    ApprovalStatus = true,
                    Tags = new List<Tag>()
                }
            );


            context.Tags.AddOrUpdate(
                t => t.TagName,
                new Tag{
                    //TagId = 1,
                    TagName = "#Blackhole"
                },
                new Tag
                {
                    //TagId = 2,
                    TagName = "#Universe"
                },
                new Tag
                {
                    //TagId = 3,
                    TagName = "#WTF"
                },
                new Tag
                {
                    //TagId = 4,
                    TagName = "#weirdscience"
                },
                new Tag
                {
                    //TagId = 5,
                    TagName = "#NBD"
                },
                new Tag
                {
                    //TagId = 5,
                    TagName = "#SPACE"
                }
            );

            context.StaticPages.AddOrUpdate(
                    s => s.StaticPageTitle,
                    new StaticPage
                    {
                    //StaticPageId = 1,
                    StaticPageTitle = "About Us",
                        StaticPageBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                        ImageFileName = "placeholder2.jpg"
                    },
                    new StaticPage
                    {
                    //StaticPageId = 2,
                    StaticPageTitle = "Disclaimer",
                        StaticPageBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                        ImageFileName = "placeholder3.jpg"
                    },
                    new StaticPage
                    {
                    //StaticPageId = 3,
                    StaticPageTitle = "Donate",
                        StaticPageBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                        ImageFileName = "placeholder4.jpg"
                    },
                    new StaticPage
                    {
                    //StaticPageId = 4,
                    StaticPageTitle = "Contact Us",
                        StaticPageBody = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent metus nisi, convallis sed tellus sit amet, congue blandit velit. In lorem erat, ornare ac leo at, blandit dapibus nunc. Maecenas ultricies neque sed elit tempus, pellentesque congue tortor rutrum. Ut scelerisque ullamcorper fringilla. Nulla facilisi. Maecenas malesuada lectus vel mi varius euismod. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nulla consequat varius sapien, ut dignissim justo placerat a." +
                        "Mauris congue, massa sit amet commodo mollis, nisl magna dictum ex, et tempus odio ex vel est. Nulla facilisi. Sed sit amet velit vitae enim faucibus gravida ut sit amet odio. Vestibulum eget quam purus. Cras rhoncus tellus id hendrerit hendrerit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Nunc imperdiet lectus at dolor consequat feugiat.Nam ac tempor sapien, nec commodo orci. Mauris id accumsan mauris. Sed a imperdiet sem. Curabitur vehicula eu ante et venenatis. Quisque ac metus elit. Donec quis interdum est. Nulla dignissim blandit dui, vitae semper lacus rhoncus eu."
                        ,
                        ImageFileName = "placeholder5.jpg"
                    }
                );


            context.SaveChanges();
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            context.Posts.Single(p => p.PostId == 1).Tags.Add(context.Tags.Single(t => t.TagId == 1));
            context.Posts.Single(p => p.PostId == 1).Tags.Add(context.Tags.Single(t => t.TagId == 2));
            context.Posts.Single(p => p.PostId == 1).Tags.Add(context.Tags.Single(t => t.TagId == 3));
            context.Posts.Single(p => p.PostId == 2).Tags.Add(context.Tags.Single(t => t.TagId == 1));
            context.Posts.Single(p => p.PostId == 2).Tags.Add(context.Tags.Single(t => t.TagId == 2));
            context.Posts.Single(p => p.PostId == 2).Tags.Add(context.Tags.Single(t => t.TagId == 4));
            context.Posts.Single(p => p.PostId == 3).Tags.Add(context.Tags.Single(t => t.TagId == 1));
            context.Posts.Single(p => p.PostId == 4).Tags.Add(context.Tags.Single(t => t.TagId == 2));
            context.Posts.Single(p => p.PostId == 5).Tags.Add(context.Tags.Single(t => t.TagId == 3));
            context.Posts.Single(p => p.PostId == 6).Tags.Add(context.Tags.Single(t => t.TagId == 4));
            // )


            //finish adding tags
            context.SaveChanges();
        }
    }
}
