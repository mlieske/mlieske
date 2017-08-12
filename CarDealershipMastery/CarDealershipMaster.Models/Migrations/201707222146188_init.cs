namespace CarDealershipMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        BodyStyleId = c.Int(nullable: false, identity: true),
                        BodyStyleType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.BodyStyleId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        ContactFirstName = c.String(maxLength: 50),
                        ContactLastName = c.String(maxLength: 50),
                        ContactPhone = c.String(maxLength: 12),
                        ContactEmail = c.String(maxLength: 50),
                        ContactMessage = c.String(maxLength: 500),
                        VehicleId = c.Int(),
                    })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        VIN = c.String(maxLength: 50),
                        Year = c.Int(nullable: false),
                        New = c.Boolean(nullable: false),
                        Mileage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MSRP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 1000),
                        Featured = c.Boolean(nullable: false),
                        Sold = c.Boolean(nullable: false),
                        ImageName = c.String(maxLength: 50),
                        IntColorId = c.Int(nullable: false),
                        ExtColorId = c.Int(nullable: false),
                        VModelId = c.Int(nullable: false),
                        BodyStyleId = c.Int(nullable: false),
                        TransTypeId = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.BodyStyles", t => t.BodyStyleId)
                .ForeignKey("dbo.ExtColors", t => t.ExtColorId)
                .ForeignKey("dbo.IntColors", t => t.IntColorId)
                .ForeignKey("dbo.VModels", t => t.VModelId)
                .ForeignKey("dbo.TransTypes", t => t.TransTypeId)
                .Index(t => t.IntColorId)
                .Index(t => t.ExtColorId)
                .Index(t => t.VModelId)
                .Index(t => t.BodyStyleId)
                .Index(t => t.TransTypeId);
            
            CreateTable(
                "dbo.ExtColors",
                c => new
                    {
                        ExtColorId = c.Int(nullable: false, identity: true),
                        ExtColorName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ExtColorId);
            
            CreateTable(
                "dbo.IntColors",
                c => new
                    {
                        IntColorId = c.Int(nullable: false, identity: true),
                        IntColorName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.IntColorId);
            
            CreateTable(
                "dbo.VModels",
                c => new
                    {
                        VModelId = c.Int(nullable: false, identity: true),
                        ModelType = c.String(maxLength: 50),
                        MakeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VModelId)
                .ForeignKey("dbo.Makes", t => t.MakeId)
                .Index(t => t.MakeId);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        MakeId = c.Int(nullable: false, identity: true),
                        MakeType = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MakeId);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(),
                        VehiclePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PriceId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.TransTypes",
                c => new
                    {
                        TransTypeId = c.Int(nullable: false, identity: true),
                        TransTypeName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.TransTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustLastName = c.String(maxLength: 50),
                        CustFirstName = c.String(maxLength: 50),
                        CustEmail = c.String(maxLength: 50),
                        CustPhone = c.String(maxLength: 12),
                        Street1 = c.String(maxLength: 100),
                        Street2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 15),
                        ZipCode = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypeId = c.Int(nullable: false, identity: true),
                        PaymentTypeDescription = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentTypeId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId)
                .Index(t => t.VehicleId)
                .Index(t => t.CustomerId)
                .Index(t => t.PaymentTypeId);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        SpecialId = c.Int(nullable: false, identity: true),
                        SpecialTitle = c.String(maxLength: 50),
                        SpecialText = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.SpecialId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Purchases", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.Purchases", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "TransTypeId", "dbo.TransTypes");
            DropForeignKey("dbo.Prices", "VehicleId", "dbo.Vehicles");
            DropForeignKey("dbo.Vehicles", "VModelId", "dbo.VModels");
            DropForeignKey("dbo.VModels", "MakeId", "dbo.Makes");
            DropForeignKey("dbo.Vehicles", "IntColorId", "dbo.IntColors");
            DropForeignKey("dbo.Vehicles", "ExtColorId", "dbo.ExtColors");
            DropForeignKey("dbo.Vehicles", "BodyStyleId", "dbo.BodyStyles");
            DropIndex("dbo.Purchases", new[] { "PaymentTypeId" });
            DropIndex("dbo.Purchases", new[] { "CustomerId" });
            DropIndex("dbo.Purchases", new[] { "VehicleId" });
            DropIndex("dbo.Prices", new[] { "VehicleId" });
            DropIndex("dbo.VModels", new[] { "MakeId" });
            DropIndex("dbo.Vehicles", new[] { "TransTypeId" });
            DropIndex("dbo.Vehicles", new[] { "BodyStyleId" });
            DropIndex("dbo.Vehicles", new[] { "VModelId" });
            DropIndex("dbo.Vehicles", new[] { "ExtColorId" });
            DropIndex("dbo.Vehicles", new[] { "IntColorId" });
            DropIndex("dbo.Contacts", new[] { "VehicleId" });
            DropTable("dbo.Specials");
            DropTable("dbo.Purchases");
            DropTable("dbo.PaymentTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.TransTypes");
            DropTable("dbo.Prices");
            DropTable("dbo.Makes");
            DropTable("dbo.VModels");
            DropTable("dbo.IntColors");
            DropTable("dbo.ExtColors");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Contacts");
            DropTable("dbo.BodyStyles");
        }
    }
}
