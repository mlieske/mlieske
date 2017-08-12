using CarDealershipMaster.Models;
using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Data.Repositories
{
    public class EFRepository : IRepository
    {
        
        CarMasteryDbContext efRepo = new CarMasteryDbContext();

        public List<Vehicle> GetAllVehicles()
        {
            var result = efRepo.Vehicles.ToList();
            return result;
        }

        public List<VModel> GetModelsByMake(int makeId)
        {
            return efRepo.VModels.Where(v => v.MakeId == makeId).ToList();
        }

        public List<Vehicle> GetFeatured()
        {
            return efRepo.Vehicles.Where(v => v.Featured == true).ToList();
        }

        public List<Vehicle> GetNewBySearch(string searchType, string searchString, decimal low, decimal high, int start, int end)
        {
            List<Vehicle> searchList;
            searchList = efRepo.Vehicles.Where(v => v.Sold == false).ToList();
            if (searchType == "New")
            {
                searchList = efRepo.Vehicles.Where(v => v.New == true).ToList(); //need to implement search criteria
            }
            else if (searchType == "Used")
            {
                searchList = efRepo.Vehicles.Where(v => v.New == false).ToList(); //need to implement search criteria
            }
            if (searchString != "none")
            {
                searchList = searchList.Where(t => t.VehicleModelId.ModelType.Contains(searchString) || t.Year.ToString() == searchString
                    || t.VehicleModelId.ModelMake.MakeType.Contains(searchString)).ToList();
            }
            searchList = searchList.Where(s => s.Price >= low).ToList();
            searchList = searchList.Where(s => s.Price <= high).ToList();
            searchList = searchList.Where(s => s.Year >= start).ToList();
            searchList = searchList.Where(s => s.Year <= end).OrderByDescending(o => o.MSRP).ToList();

            return searchList;
        }

        public List<Vehicle> GetUsedBySearch(string searchString, decimal low, decimal high, int start, int end)
        {
            return efRepo.Vehicles.Where(v => v.New == false).ToList(); //need to implement search criteria
        }

        public Vehicle GetVehicleById(int id)
        {
            return efRepo.Vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        public List<Special> GetSpecials()
        {
            return efRepo.Specials.ToList();
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            return efRepo.BodyStyles.ToList();
        }

        public List<ExtColor> GetAllExtColors()
        {
            return efRepo.ExtColors.ToList();
        }

        public List<IntColor> GetAllIntColors()
        {
            return efRepo.IntColors.ToList();
        }

        public List<Make> GetAllMakes()
        {
            return efRepo.Makes.ToList();
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return efRepo.PaymentTypes.ToList();
        }

        public List<TransType> GetAllTransTypes()
        {
            return efRepo.TransTypes.ToList();
        }

        public List<VModel> GetAllVModels()
        {
            return efRepo.VModels.ToList();
        }


        public Make GetMakeByModel(VModel model)
        {
            return efRepo.Makes.FirstOrDefault(m => m.MakeId == model.MakeId);
        }

        public void AddContact(Contact contact)
        {
            efRepo.ContactList.Add(contact);
            efRepo.SaveChanges();

        }

        public int AddCustomer(Customer customer)
        {
            efRepo.Customers.Add(customer);
            efRepo.SaveChanges();
            return efRepo.Customers.Max(c => c.CustomerId);
        }

        public void AddPurchase(Purchase purchase)
        {
            efRepo.Purchases.Add(purchase);
            efRepo.SaveChanges();

        }

        public int AddNewVehicle(Vehicle vehicle)
        { 
            efRepo.Vehicles.Add(vehicle);
            efRepo.SaveChanges();
            return efRepo.Vehicles.Max(v => v.VehicleId);
        }

        public void EditVehicle(Vehicle vehicle) //vehicle id instaed?
        {
            var ev = efRepo.Vehicles.FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);

            ev.BodyStyleId = vehicle.BodyStyleId;
            ev.DateAdded = vehicle.DateAdded;
            ev.Description = vehicle.Description;
            ev.ExtColorId = vehicle.ExtColorId;
            ev.Featured = vehicle.Featured;
            ev.ImageName = vehicle.ImageName;
            ev.IntColorId = vehicle.IntColorId;
            ev.Mileage = vehicle.Mileage;
            ev.MSRP = vehicle.MSRP;
            ev.New = vehicle.New;
            ev.Sold = vehicle.Sold;
            ev.TransTypeId = vehicle.TransTypeId;
            ev.VIN = vehicle.VIN;
            ev.VModelId = vehicle.VModelId;
            ev.Year = vehicle.Year;
            ev.VehicleId = vehicle.VehicleId;

            efRepo.Entry(ev).State = EntityState.Modified;


            efRepo.SaveChanges();
            //will be a view model that includes make and model lists?
        }

        public void DeleteVehicle(int id)
        {
            var result = efRepo.Vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (result != null)
            {
                efRepo.Vehicles.Remove(result);
                efRepo.SaveChanges();

            }
        }

        public void AddMake(Make make)
        {
            efRepo.Makes.Add(make);
            efRepo.SaveChanges();

        }

        public void AddModel(VModel model)
        {
            efRepo.VModels.Add(model);
            efRepo.SaveChanges();

        }

        public void AddSpecial(Special special)
        {
            efRepo.Specials.Add(special);
            efRepo.SaveChanges();
        }

        public void DeleteSpecial(int id)
        {
            var result = efRepo.Specials.FirstOrDefault(s => s.SpecialId == id);
            if (result != null)
            {
                efRepo.Specials.Remove(result);
                efRepo.SaveChanges();
            }
        }

        public List<Purchase> GetPurchases()
        {
            return efRepo.Purchases.ToList();
        }

    }
}
