namespace SpaceBlog.UI.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SpaceBlog.UI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaceBlog.UI.Models.SpaceBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaceBlog.UI.Models.SpaceBlogDbContext context)
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

            //if( !System.Diagnostics.Debugger.IsAttached )
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (!roleMgr.RoleExists("admin"))
            {
                // create the admin role
                roleMgr.Create(new AppRole() { Name = "admin" });
            }

            if (!roleMgr.RoleExists("contributor"))
            {
                // create the admin role
                roleMgr.Create(new AppRole() { Name = "contributor" });
            }

            if( !userMgr.Users.Any(  u=> u.UserName == "admintest"))
            {
                // create the default user 
                var user = new AppUser()
                {
                    UserName = "admintest"
                };

                // create the user with the manager class
                var result = userMgr.Create(user, "testing123");
                if( result.Succeeded )
                {

                    // add the user to the admin role
                    userMgr.AddToRole(user.Id, "admin");
                }
                else
                {
                    throw new Exception(string.Join(" ", result.Errors.ToArray()));
                }


            }

            if (!userMgr.Users.Any(u => u.UserName == "contributortest"))
            {

                var user2 = new AppUser()
                {
                    UserName = "contributortest"
                };

                userMgr.Create(user2, "testing123");
                userMgr.AddToRole(user2.Id, "contributor");
            }
        }
    }
}
