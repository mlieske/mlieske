using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBlog.UI.Models
{
    public class SpaceBlogDbContext : IdentityDbContext<AppUser>
    {
        public SpaceBlogDbContext() : base("SpaceBlog")
        {

        }
    }
}