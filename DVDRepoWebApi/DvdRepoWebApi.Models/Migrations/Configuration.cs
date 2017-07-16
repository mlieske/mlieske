namespace DvdRepoWebApi.Models.Migrations
{
    using DVDRepoWebApi.Models.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDRepoWebApi.Models.Models.DVDCatalogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDRepoWebApi.Models.Models.DVDCatalogEntities context)
        {
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

            context.Ratings.AddOrUpdate(
                r => r.RatingId,
                new Rating
                {
                    RatingId = 0,
                    RatingType = "G"
                },
                new Rating
                {
                    RatingId = 1,
                    RatingType = "PG"
                },
                new Rating
                {
                    RatingId = 2,
                    RatingType = "PG-13"
                },
                new Rating
                {
                    RatingId = 3,
                    RatingType = "R"
                }
            );

            context.Directors.AddOrUpdate(
                d => d.DirectorId,
                new Director
                {
                    DirectorId = 0,
                    DirectorName = "George Lucas"
                },
                new Director
                {
                    DirectorId = 1,
                    DirectorName = "Sam Jones"
                },
                new Director
                {
                    DirectorId = 2,
                    DirectorName = "Joe Smith"
                });

            context.DVDs.AddOrUpdate(
                d => d.DvdId,
                new DVD
                {
                    DvdId = 0,
                    Title = "A Great Tale",
                    RealeaseYear = 2015,
                    DirectorId = 1,
                    RatingId = 1,
                    Notes = "A great remake!"
                },
                new DVD
                {
                    DvdId = 1,
                    Title = "A Great Tale",
                    RealeaseYear = 1985,
                    DirectorId = 2,
                    RatingId = 1,
                    Notes = "The Original!"
                },
                new DVD
                {
                    DvdId = 2,
                    Title = "Testing ADO",
                    RealeaseYear = 2000,
                    DirectorId = 2,
                    RatingId = 3,
                    Notes = "Only in SQL database"
                }
                );
        }
    }
}
