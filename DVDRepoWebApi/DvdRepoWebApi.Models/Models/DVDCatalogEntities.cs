using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DVDRepoWebApi.Models.Models
{
    public class DVDCatalogEntities : DbContext
    {
        public DVDCatalogEntities() : base("DVDCatalog")
        {

        }

        public DbSet<DVD> DVDs { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
}