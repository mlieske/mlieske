namespace CarDealershipMaster.Models.Migrations
{
    using CarDealershipMastery.Models.TableModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Globalization;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealershipMaster.Models.CarMasteryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CarDealershipMaster.Models.CarMasteryDbContext context)
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
            //public virtual DbSet<Special> Specials { get; set; }
            //public virtual DbSet<TransType> Transmissions { get; set; }
            //public virtual DbSet<BodyStyle> BodyStyles { get; set; }
            //public virtual DbSet<ExtColor> ExtColors { get; set; }
            //public virtual DbSet<IntColors> IntColors { get; set; }
            //public virtual DbSet<Make> Makes { get; set; }
            //public virtual DbSet<VModel> VModels { get; set; }
            //public virtual DbSet<PaymentType> PaymentTypes { get; set; }
            //public virtual DbSet<Customer> Customers { get; set; }
            //public virtual DbSet<Vehicle> Vehicles { get; set; }
            //public virtual DbSet<Price> Prices { get; set; }
            //public virtual DbSet<Contact> ContactList { get; set; }
            //public virtual DbSet<Purchase> Purchases { get; set; }

            context.Specials.AddOrUpdate(
                s => s.SpecialTitle,
                new Special
                {
                    SpecialTitle = "Wednesday Special",
                    SpecialText = "This Wednesday get 20% off!  Don't forget to come in and take advantage of the sale"
                },
                new Special
                {
                    SpecialTitle = "Thursday Special",
                    SpecialText = "This Thursday get 25% off!  No exceptions, everything is on sale"
                }
                );

            context.TransTypes.AddOrUpdate(
                t => t.TransTypeName,
                new TransType { TransTypeName = "Automatic" }, new TransType { TransTypeName = "Manual" }
                );

            context.BodyStyles.AddOrUpdate(
                b => b.BodyStyleType,
                new BodyStyle { BodyStyleType = "Car" },
                new BodyStyle { BodyStyleType = "SUV" },
                new BodyStyle { BodyStyleType = "Truck" },
                new BodyStyle { BodyStyleType = "Van" }
                );

            context.ExtColors.AddOrUpdate(
                e => e.ExtColorName,
                new ExtColor { ExtColorName = "Silver" },
                new ExtColor { ExtColorName = "Black" },
                new ExtColor { ExtColorName = "Red" },
                new ExtColor { ExtColorName = "Maroon" },
                new ExtColor { ExtColorName = "Blud" }
                );

            context.IntColors.AddOrUpdate(
                i => i.IntColorName,
                new IntColor { IntColorName = "Gray" },
                new IntColor { IntColorName = "Tan" },
                new IntColor { IntColorName = "Black" },
                new IntColor { IntColorName = "White" },
                new IntColor { IntColorName = "Navy" }
                );

            context.Makes.AddOrUpdate(
                m => m.MakeType,
                new Make { MakeType = "Hyundai" },
                new Make { MakeType = "BMW" },
                new Make { MakeType = "Honda" },
                new Make { MakeType = "Toyota" },
                new Make { MakeType = "Tesla" }
                );

            context.SaveChanges();

            context.VModels.AddOrUpdate(
                m => m.ModelType,
                new VModel { ModelType = "Santa Fe", MakeId = context.Makes.FirstOrDefault(m => m.MakeType == "Hyundai").MakeId },
                new VModel { ModelType = "325", MakeId = context.Makes.FirstOrDefault(m => m.MakeType == "BMW").MakeId },
                new VModel { ModelType = "Odyssey", MakeId = context.Makes.FirstOrDefault(m => m.MakeType == "Honda").MakeId },
                new VModel { ModelType = "Accord", MakeId = context.Makes.FirstOrDefault(m => m.MakeType == "Honda").MakeId }
                );

            context.SaveChanges();

            context.PaymentTypes.AddOrUpdate(
                p => p.PaymentTypeDescription,
                new PaymentType { PaymentTypeDescription = "Bank Finance" },
                new PaymentType { PaymentTypeDescription = "Cash" },
                new PaymentType { PaymentTypeDescription = "Dealer Finance" }
                );

            context.Customers.AddOrUpdate(
                c => c.CustEmail,
                new Customer
                {
                    CustLastName = "Jones",
                    CustFirstName = "Sam",
                    CustEmail = "sjones@sj.com",
                    CustPhone = "555-555-5555",
                    Street1 = "123 Street",
                    Street2 = "",
                    City = "Minneapolis",
                    State = "Minnesota",
                    ZipCode = "55410"
                }
                );

            context.SaveChanges();

            context.Vehicles.AddOrUpdate(
                v => v.VIN,
                new Vehicle
                {
                    VIN = "123",
                    Year = 2014,
                    New = true,
                    Mileage = 4000,
                    MSRP = 32500,
                    Description = "This is a great brand new car",
                    Featured = true,
                    Sold = false,
                    ImageName = "vehicle1.jpg",
                    ExtColorId = 1,
                    BodyStyleId = 1,
                    TransTypeId = 1,
                    Price=30000,
                    DateAdded = DateTime.ParseExact("07/16/2017", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    IntColorId = 1,
                    VModelId = 1
                },
                new Vehicle
                {
                    VIN = "456",
                    Year = 2004,
                    New = false,
                    Mileage = 34000,
                    MSRP = 21500,
                    Description = "This is a great used car",
                    Featured = false,
                    Sold = false,
                    ImageName = "vehicle2.jpg",
                    ExtColorId = 3,
                    BodyStyleId = 2,
                    TransTypeId = 2,
                    Price = 20000,
                    DateAdded = DateTime.ParseExact("06/10/2017", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    IntColorId = 4,
                    VModelId = 2
                });

            context.SaveChanges();


            context.ContactList.AddOrUpdate(
                new Contact
                {
                    ContactFirstName = "John",
                    ContactLastName = "Smith",
                    ContactPhone = "444-444-4444",
                    ContactEmail = "js@js.com",
                    ContactMessage = "I am very interested in this car!",
                    VehicleId = 2
                });
            context.SaveChanges();

        }
    }
}
