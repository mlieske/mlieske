using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMaster.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        
        [Test]
        public void TestGetAll()
        {
            var repo = new MockRepository();
            var result = repo.GetAllVehicles();

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("123", result.ElementAt(0).VIN);
        }

        [Test]
        public void EditVehicle()
        {
            var repo = new MockRepository();
            Vehicle editedVehicle = new Vehicle();
            editedVehicle.VehicleId = 4;
            editedVehicle.VIN = "456";
            editedVehicle.Year = 2004;
            editedVehicle.New = false;
            editedVehicle.Mileage = 34000;
            editedVehicle.MSRP = 21500;
            editedVehicle.Description = "This is a great used car";
            editedVehicle.Featured = false;
            editedVehicle.Sold = false;
            editedVehicle.ImageName = "vehicle2";
            editedVehicle.ExtColorId = 3;
            editedVehicle.BodyStyleId = 3;
            editedVehicle.TransTypeId = 2;
            editedVehicle.DateAdded = DateTime.ParseExact("06/10/2017", "MM/d/yyyy", CultureInfo.InvariantCulture);
            editedVehicle.IntColorId = 4;
            editedVehicle.VModelId = 2;
            repo.EditVehicle(editedVehicle);

            var result = repo.GetVehicleById(editedVehicle.VehicleId);

            Assert.AreEqual(3, result.BodyStyleId);
        }

        [Test]
        public void AddVehicle()
        {
            var repo = new MockRepository();
            Vehicle editedVehicle = new Vehicle();
            editedVehicle.VehicleId = 5;
            editedVehicle.VIN = "789";
            editedVehicle.Year = 2004;
            editedVehicle.New = false;
            editedVehicle.Mileage = 34000;
            editedVehicle.MSRP = 21500;
            editedVehicle.Description = "This is a great used car";
            editedVehicle.Featured = false;
            editedVehicle.Sold = false;
            editedVehicle.ImageName = "vehicle2";
            editedVehicle.ExtColorId = 3;
            editedVehicle.BodyStyleId = 3;
            editedVehicle.TransTypeId = 2;
            editedVehicle.DateAdded = DateTime.ParseExact("06/10/2017", "MM/d/yyyy", CultureInfo.InvariantCulture);
            editedVehicle.IntColorId = 4;
            editedVehicle.VModelId = 2;
            repo.AddNewVehicle(editedVehicle);

            var result = repo.GetAllVehicles();
            var result2 = repo.GetVehicleById(5);

            Assert.AreEqual(3, result.Count());
            Assert.AreEqual("789", result2.VIN);
        }

        [Test]
        public void TestSpecialDelete()
        {
            var repo = new MockRepository();
            repo.DeleteSpecial(2);
            var result = repo.GetSpecials();
            Assert.AreEqual(1, result.Count());
        }

    }
}
