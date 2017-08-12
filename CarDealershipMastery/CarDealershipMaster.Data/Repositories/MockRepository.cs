using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipMastery.Data.Repositories
{
    public class MockRepository : IRepository
    {
        private static List<BodyStyle> _bodyStyles = new List<BodyStyle>();
        private static List<Contact> _contacts = new List<Contact>();
        private static List<Customer> _customers = new List<Customer>();
        private static List<ExtColor> _extColors = new List<ExtColor>();
        private static List<IntColor> _intColors = new List<IntColor>();
        private static List<Make> _makes = new List<Make>();
        private static List<PaymentType> _paymentTypes = new List<PaymentType>();
        private static List<Purchase> _purchases = new List<Purchase>();
        private static List<Special> _specials = new List<Special>();
        private static List<TransType> _transTypes = new List<TransType>();
        private static List<Vehicle> _vehicles = new List<Vehicle>();
        private static List<VModel> _vmodels = new List<VModel>();

        public MockRepository()
        {

            _specials = new List<Special> {
                    new Special
                    {
                        SpecialId = 1,
                        SpecialTitle = "Wednesday Special",
                        SpecialText = "This Wednesday get 20% off!  Don't forget to come in and take advantage of the sale"
                    },
                    new Special
                    {
                        SpecialId = 2,
                        SpecialTitle = "Thursday Special",
                        SpecialText = "This Thursday get 25% off!  No exceptions, everything is on sale"
                    }
            };

            _transTypes = new List<TransType> {
                new TransType { TransTypeId = 1, TransTypeName = "Automatic" },
                new TransType { TransTypeId = 2, TransTypeName = "Manual" }
            };

            _bodyStyles = new List<BodyStyle> {
                new BodyStyle {BodyStyleId = 1, BodyStyleType = "Car" },
                new BodyStyle {BodyStyleId = 2, BodyStyleType = "SUV" },
                new BodyStyle {BodyStyleId = 3, BodyStyleType = "Truck" },
                new BodyStyle {BodyStyleId = 4, BodyStyleType = "Van" }
                };

            _extColors = new List<ExtColor> {
                new ExtColor {ExtColorId = 1, ExtColorName = "Silver" },
                new ExtColor {ExtColorId = 2, ExtColorName = "Black" },
                new ExtColor {ExtColorId = 3, ExtColorName = "Red" },
                new ExtColor {ExtColorId = 4, ExtColorName = "Maroon" },
                new ExtColor {ExtColorId = 5, ExtColorName = "Blud" }
                };

            _intColors = new List<IntColor> {
                new IntColor {IntColorId = 1, IntColorName = "Gray" },
                new IntColor {IntColorId = 2, IntColorName = "Tan" },
                new IntColor {IntColorId = 3, IntColorName = "Black" },
                new IntColor {IntColorId = 4, IntColorName = "White" },
                new IntColor {IntColorId = 5, IntColorName = "Navy" }
                };

            _makes = new List<Make> {
                new Make {MakeId = 1, MakeType = "Hyundai" },
                new Make {MakeId = 2, MakeType = "BMW" },
                new Make {MakeId = 3, MakeType = "Honda" },
                new Make {MakeId = 4, MakeType = "Toyota" },
                new Make {MakeId = 5, MakeType = "Tesla" }
                };

            _vmodels = new List<VModel> {
                new VModel {VModelId = 1, ModelType = "Santa Fe", MakeId = 1 },
                new VModel {VModelId = 2, ModelType = "325", MakeId = 2 },
                new VModel {VModelId = 3, ModelType = "Odyssey", MakeId = 3 },
                new VModel {VModelId = 4, ModelType = "Accord", MakeId = 3 }
                };


            _paymentTypes = new List<PaymentType> {
                new PaymentType {PaymentTypeId = 1, PaymentTypeDescription = "Bank Finance" },
                new PaymentType {PaymentTypeId = 2, PaymentTypeDescription = "Cash" },
                new PaymentType {PaymentTypeId = 3, PaymentTypeDescription = "Dealer Finance" }
                };

            _customers = new List<Customer> {
                new Customer
                {
                    CustomerId = 1,
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
                };

            _vehicles = new List<Vehicle> {
                new Vehicle
                {
                    VehicleId = 3,
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
                    DateAdded = DateTime.ParseExact("07/16/2017", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    IntColorId = 1,
                    VModelId = 1
                },
                new Vehicle
                {
                    VehicleId = 4,
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
                    DateAdded = DateTime.ParseExact("06/10/2017", "MM/d/yyyy", CultureInfo.InvariantCulture),
                    IntColorId = 4,
                    VModelId = 2
                }};


            _contacts = new List<Contact> {
                new Contact
                {
                    ContactId = 1,
                    ContactFirstName = "John",
                    ContactLastName = "Smith",
                    ContactPhone = "444-444-4444",
                    ContactEmail = "js@js.com",
                    ContactMessage = "I am very interested in this car!",
                    VehicleId = 3
                }};

            _purchases = new List<Purchase>
            {
            };
        }

        public List<Vehicle> GetAllVehicles()
        {
            return _vehicles;
        }

        public List<VModel> GetModelsByMake(int makeId)
        {
            return _vmodels.Where(v => v.MakeId == makeId).ToList();
        }

        public List<Vehicle> GetFeatured()
        {
            return _vehicles.Where(v => v.Featured == true).ToList();
        }

        public List<Vehicle> GetNewBySearch(string searchType, string searchString, decimal low, decimal high, int start, int end)
        {
            return _vehicles.Where(v => v.New == true).ToList();
        }

        public List<Vehicle> GetUsedBySearch(string searchString, decimal low, decimal high, int start, int end)
        {
            return _vehicles.Where(v => v.New == false).ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleId == id);
        }

        public List<Special> GetSpecials()
        {
            return _specials;
        }

        public List<BodyStyle> GetAllBodyStyles()
        {
            return _bodyStyles;
        }

        public List<ExtColor> GetAllExtColors()
        {
            return _extColors;
        }

        public List<IntColor> GetAllIntColors()
        {
            return _intColors;
        }

        public List<Make> GetAllMakes()
        {
            return _makes;
        }

        public List<PaymentType> GetAllPaymentTypes()
        {
            return _paymentTypes;
        }

        public List<TransType> GetAllTransTypes()
        {
            return _transTypes;
        }

        public List<VModel> GetAllVModels()
        {
            return _vmodels;
        }

        public Make GetMakeByModel(VModel model)
        {
            return _makes.FirstOrDefault(m => m.MakeId == model.MakeId);
        }

        public void AddContact(Contact contact)
        {
            var nextId = _contacts.Max(v => v.ContactId) + 1;
            contact.ContactId = nextId;
            _contacts.Add(contact);
        }

        public int AddCustomer(Customer customer)
        {
            var nextId = _customers.Max(v => v.CustomerId) + 1;
            customer.CustomerId = nextId;
            _customers.Add(customer);
            return _customers.Max(c => c.CustomerId);
        }



        public void AddPurchase(Purchase purchase)
        {
            var nextId = _purchases.Max(v => v.PurchaseId) + 1;
            purchase.PurchaseId = nextId;
            _purchases.Add(purchase);
        }
       
        public int AddNewVehicle(Vehicle vehicle)
        {
            var nextId = _vehicles.Max(v => v.VehicleId) + 1;
            vehicle.VehicleId = nextId;
            _vehicles.Add(vehicle);
            return _vehicles.Max(v => v.VehicleId);
        }

        public void EditVehicle(Vehicle vehicle) //vehicle id instaed?
        {
            var ev = _vehicles.FirstOrDefault(v => v.VehicleId == vehicle.VehicleId);

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
            //will be a view model that includes make and model lists?
        }

        public void DeleteVehicle(int id)
        {
            var result = _vehicles.FirstOrDefault(v => v.VehicleId == id);
            if (result != null)
            {
                _vehicles.Remove(result);
            }
        }

        public void AddMake(Make make)
        {
            _makes.Add(make);
        }

        public void AddModel(VModel model)
        {
            _vmodels.Add(model);
        }


        public void AddSpecial(Special special)
        {
            _specials.Add(special);
        }

        public void DeleteSpecial(int id)
        {
            var result = _specials.FirstOrDefault(s => s.SpecialId == id);
            if (result != null)
            {
                _specials.Remove(result);
            }
        }

        public List<Purchase> GetPurchases()
        {
            return _purchases;
            //need to limit results by search here or in controller?
        }
    }
}
