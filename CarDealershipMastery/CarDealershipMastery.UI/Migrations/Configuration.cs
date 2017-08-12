namespace CarDealershipMastery.UI.Migrations
{
    using CarDealershipMastery.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipMastery.UI.Models.CarMasteryIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealershipMastery.UI.Models.CarMasteryIdentityDbContext context)
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

            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            if (roleMgr.RoleExists("admin"))
                return;
            if (roleMgr.RoleExists("sales"))
                return;
            if (roleMgr.RoleExists("disabled"))
                return;

            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "sales" });
            roleMgr.Create(new AppRole() { Name = "disabled" });

            var user1 = new AppUser()
            {
                UserName = "admin"
            };

            var user2 = new AppUser()
            {
                UserName = "sales"
            };

            userMgr.Create(user1, "admin123");
            userMgr.Create(user2, "sales123");

            userMgr.AddToRole(user1.Id, "admin");
            userMgr.AddToRole(user2.Id, "sales");
        }
    }
}
