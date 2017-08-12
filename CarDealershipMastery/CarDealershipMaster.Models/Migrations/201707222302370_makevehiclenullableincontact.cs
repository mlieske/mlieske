namespace CarDealershipMaster.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makevehiclenullableincontact : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Contacts", new[] { "VehicleId" });
            AlterColumn("dbo.Contacts", "VehicleId", c => c.Int());
            CreateIndex("dbo.Contacts", "VehicleId");
            AddForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles", "VehicleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Contacts", new[] { "VehicleId" });
            AlterColumn("dbo.Contacts", "VehicleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contacts", "VehicleId");
            AddForeignKey("dbo.Contacts", "VehicleId", "dbo.Vehicles", "VehicleId", cascadeDelete: true);
        }
    }
}
