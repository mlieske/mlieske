using CarDealershipMaster.Models;
using CarDealershipMastery.Data;
using CarDealershipMastery.Data.Interfaces;
using CarDealershipMastery.Models.TableModels;
using CarDealershipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipMastery.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IRepository _repo;

        public AdminController()
        {
            _repo = RepositoryFactory.Create();
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="admin, sales")]
        public ActionResult Vehicles()
        {
            SearchType searchType = new SearchType();
            searchType.SearchCategory = "Both";
            return View("SearchVehicles", "Inventory", searchType);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            VehicleEntryVM model = new VehicleEntryVM();
            model.SetBodyStyles(_repo.GetAllBodyStyles());
            model.SetExtColors(_repo.GetAllExtColors());
            model.SetIntColors(_repo.GetAllIntColors());
            model.SetMakes(_repo.GetAllMakes());
            model.SetPaymentTypes(_repo.GetAllPaymentTypes());
            model.SetTransType(_repo.GetAllTransTypes());
            model.SetVModels(_repo.GetAllVModels());
            model.SetTypes(); // new Dictionary<string, bool>() { { "New", true }, { "Used", false } });
            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleEntryVM vehicleVM)
        {
            if (vehicleVM.ImageUpload != null && vehicleVM.ImageUpload.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Website IMAGES");

                string fileName = Path.GetFileNameWithoutExtension(vehicleVM.ImageUpload.FileName);
                string extension = Path.GetExtension(vehicleVM.ImageUpload.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                vehicleVM.ImageUpload.SaveAs(filePath);
                vehicleVM.VehicleDetails.ImageName = Path.GetFileName(filePath);

            }

            vehicleVM.VehicleDetails.DateAdded = DateTime.Now;
            _repo.AddNewVehicle(vehicleVM.VehicleDetails);

            return RedirectToAction("EditVehicle",vehicleVM.VehicleDetails.VehicleId);

        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            VehicleEntryVM model = new VehicleEntryVM();
            model.VehicleDetails = _repo.GetVehicleById(id);
            model.VehicleMake = _repo.GetMakeByModel(model.VehicleDetails.VehicleModelId);
            model.SetBodyStyles(_repo.GetAllBodyStyles());
            model.SetExtColors(_repo.GetAllExtColors());
            model.SetIntColors(_repo.GetAllIntColors());
            model.SetMakes(_repo.GetAllMakes());
            model.SetPaymentTypes(_repo.GetAllPaymentTypes());
            model.SetTransType(_repo.GetAllTransTypes());
            model.SetVModels(_repo.GetAllVModels());
            model.SetTypes(); // new Dictionary<string, bool>() { { "New", true }, { "Used", false } });
            return View(model);
        }

        [HttpPost]
        public ActionResult EditVehicle(VehicleEntryVM vehicleVM)
        {
            if (vehicleVM.ImageUpload != null && vehicleVM.ImageUpload.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Website IMAGES");

                string fileName = Path.GetFileNameWithoutExtension(vehicleVM.ImageUpload.FileName);
                string extension = Path.GetExtension(vehicleVM.ImageUpload.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                vehicleVM.ImageUpload.SaveAs(filePath);
               vehicleVM.VehicleDetails.ImageName = Path.GetFileName(filePath);

            }


            _repo.EditVehicle(vehicleVM.VehicleDetails);

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            var model = _repo.GetVehicleById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteVehicle(Vehicle vehicle)
        {
            _repo.DeleteVehicle(vehicle.VehicleId);
            return RedirectToAction("Vehicles");
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
                var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
                var context = new CarMasteryIdentityDbContext();

                List<UpdateAccountViewModel> model = new List<UpdateAccountViewModel>();

                var listOfUsers = context.Users;
                foreach(var u in listOfUsers)
                {
                    UpdateAccountViewModel user = new UpdateAccountViewModel();
                    user.UserId = u.Id;
                    user.UserName = u.UserName;
                    user.FirstName = u.FirstName;
                    user.LastName = u.LastName;
                    user.EmailAddress = u.Email;
                    user.UserRole = userManager.GetRoles(user.UserId).FirstOrDefault();
                    model.Add(user);
                }

                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet]
        public ActionResult AddUser()
        {
            var model = new UpdateAccountViewModel();

            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
            var roles = roleManager.Roles.ToList();

            List<string> rolelist = new List<string>();
            foreach (var role in roles)
            {
                rolelist.Add(role.Name);
            }

            model.Roles = new SelectList(rolelist, "", "");

            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UpdateAccountViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            var user = new AppUser
            {
                UserName = model.UserName,
                Email = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = userManager.Create(user, model.Password);
            userManager.AddToRole(user.Id, model.UserRole);

            return RedirectToAction("GetUsers", "Admin");

        }

        [HttpGet]
        public ActionResult ViewAccount()
        {
            return View();
        }

        public ActionResult EditUsers(string id)
        {
            var model = new UpdateAccountViewModel();
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();
            var roles = roleManager.Roles.ToList();


            var user = userManager.Users.ToList().FirstOrDefault(u => u.UserName == id);
            model.UserId = user.Id;
            model.EmailAddress = user.Email;
            model.UserName = user.UserName;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;

            model.UserRole = userManager.GetRoles(user.Id).FirstOrDefault();

            List<string> rolelist = new List<string>();
            foreach (var role in roles)
            {
                rolelist.Add(role.Name);
            }

            model.Roles = new SelectList(rolelist, "", "");

            return View(model);

        }

        [HttpPost]
        public ActionResult EditUsers(UpdateAccountViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            var user = userManager.FindById(model.UserId);

            // get all roles
            var roles = roleManager.Roles.ToList();

            // removing all roles for this user
            userManager.RemoveFromRoles(model.UserId, userManager.GetRoles(model.UserId).ToArray());

            // add selected role for this user
            userManager.AddToRole(model.UserId, model.UserRole);

            if (model.Password == model.PasswordConfirm)
            {
                userManager.RemovePassword(model.UserId);
                userManager.AddPassword(model.UserId, model.Password);
            }
            user.Email = model.EmailAddress;
            //user.UserName = .UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            userManager.Update(user);

            return RedirectToAction("GetUsers", "Admin");
        }

        [Authorize(Roles = "admin, sales")]
        public ActionResult ChangePassword(string id)
        {
            UpdateAccountViewModel model = new UpdateAccountViewModel();
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var user = userManager.FindByName(id);
            model.UserId = user.Id;
            model.UserName = user.UserName;
            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(UpdateAccountViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var user = userManager.FindByName(model.UserId);
            
            if (model.Password == model.PasswordConfirm)
            {
                userManager.RemovePassword(model.UserId);
                userManager.AddPassword(model.UserId, model.Password);
            }

            return RedirectToAction("GetUsers", "Admin");
        }

        public ActionResult DeleteUser(string id)
        {
            // commented code to delet user
            //var context = new SpaceBlogDbContext();
            //context.Users.Remove(context.Users.Single(u => u.UserName == id));
            //context.SaveChanges();

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            var user = userManager.Users.ToList().FirstOrDefault(u => u.UserName == id);

            // removing all roles for this user
            userManager.RemoveFromRoles(user.Id, userManager.GetRoles(user.Id).ToArray());

            userManager.Update(user);

            return RedirectToAction("GetUsers", "Admin");
        }

        [HttpGet]
        public ActionResult Specials() //add new and delete from list
        {
            ManageSpecialsVM model = new ManageSpecialsVM();
            model.VMAllSpecials = _repo.GetSpecials();

            return View(model);
        }


        [HttpPost]
        public ActionResult Specials(ManageSpecialsVM special)
        {
            _repo.AddSpecial(special.VMSpecial);
            ManageSpecialsVM model = new ManageSpecialsVM();
            Special blank = new Special();
            model.VMAllSpecials = _repo.GetSpecials();
            model.VMSpecial = blank;
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            var getAll = _repo.GetSpecials();
            var model = getAll.FirstOrDefault(m => m.SpecialId == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteSpecial(Special special)
        {
            _repo.DeleteSpecial(special.SpecialId);
            return RedirectToAction("Specials");

        }

        [HttpGet]
        public ActionResult Makes()
        {
            NewMakeVM model = new NewMakeVM();
            model.AllMakes = _repo.GetAllMakes();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(NewMakeVM make)
        {
            _repo.AddMake(make.NewMake);
            make.AllMakes = _repo.GetAllMakes();
            return View(make);
        }

        [HttpGet]
        public ActionResult Models()
        {
            NewModelVM model = new NewModelVM();
            model.AllModels = _repo.GetAllVModels();
            model.SetAllMakes(_repo.GetAllMakes());

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(NewModelVM vmodel)
        {
            _repo.AddModel(vmodel.NewModel);
            vmodel.AllModels = _repo.GetAllVModels();
            vmodel.SetAllMakes(_repo.GetAllMakes());
            return View(vmodel);

        }






    }
}