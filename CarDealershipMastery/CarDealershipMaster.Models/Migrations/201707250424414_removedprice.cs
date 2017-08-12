namespace CarDealershipMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedprice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prices", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Prices", new[] { "VehicleId" });
            AddColumn("dbo.Vehicles", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropTable("dbo.Prices");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.PriceId);
            
            DropColumn("dbo.Vehicles", "Price");
            CreateIndex("dbo.Prices", "VehicleId");
            AddForeignKey("dbo.Prices", "VehicleId", "dbo.Vehicles", "VehicleId", cascadeDelete: true);
        }
    }
}
