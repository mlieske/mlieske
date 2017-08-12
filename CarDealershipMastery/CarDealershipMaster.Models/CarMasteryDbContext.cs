using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMaster.Models
{
    public class CarMasteryDbContext : DbContext
    {
        public CarMasteryDbContext() : base("CarMastery")
        {

        }

        public virtual DbSet<BodyStyle> BodyStyles { get; set; }
        public virtual DbSet<Contact> ContactList { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<ExtColor> ExtColors { get; set; }
        public virtual DbSet<IntColor> IntColors { get; set; }
        public virtual DbSet<Make> Makes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Special> Specials { get; set; }
        public virtual DbSet<TransType> TransTypes { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VModel> VModels { get; set; }
    }
}
