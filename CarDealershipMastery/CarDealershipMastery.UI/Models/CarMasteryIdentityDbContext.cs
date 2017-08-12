using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealershipMastery.UI.Models
{
    public class CarMasteryIdentityDbContext : IdentityDbContext<AppUser>
    {
        public CarMasteryIdentityDbContext() : base("CarMastery")
        {

        }
    }
}