using CarDealershipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Data.Interfaces
{
    public interface IRepository
    {
        List<Vehicle> GetAllVehicles();
        List<VModel> GetModelsByMake(int makeId);
        List<Vehicle> GetFeatured();
        List<Vehicle> GetNewBySearch(string searchType, string searchString, decimal low, decimal high, int start, int end);
        List<Vehicle> GetUsedBySearch(string searchString, decimal low, decimal high, int start, int end);
        Vehicle GetVehicleById(int id);
        List<Special> GetSpecials();
        List<BodyStyle> GetAllBodyStyles();
        List<ExtColor> GetAllExtColors();
        List<IntColor> GetAllIntColors();
        List<Make> GetAllMakes();
        List<PaymentType> GetAllPaymentTypes();
        List<TransType> GetAllTransTypes();
        List<VModel> GetAllVModels();
        Make GetMakeByModel(VModel model);
        void AddContact(Contact contact);
        int AddCustomer(Customer customer);
        void AddPurchase(Purchase purchase);
        int AddNewVehicle(Vehicle vehicle);
        void EditVehicle(Vehicle vehicle); //vehicle id instaed?
        void DeleteVehicle(int id);
        void AddMake(Make make);
        void AddModel(VModel model);
        void AddSpecial(Special special);
        void DeleteSpecial(int id);
        List<Purchase> GetPurchases();
    }
}
