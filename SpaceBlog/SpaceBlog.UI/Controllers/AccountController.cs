using SpaceBlog.Data;
using SpaceBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaceBlog.Models.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using SpaceBlog.UI.Models;
using Microsoft.AspNet.Identity.Owin;

namespace SpaceBlog.UI.Controllers
{
    public class AccountController : Controller
    {
        private ISpaceBlogRepository _SpaceBlogRepo;

        public AccountController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: Account
        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index(UpdateAccountViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var roleManager = HttpContext.GetOwinContext().GetUserManager<RoleManager<AppRole>>();

            var user = new AppUser { UserName = model.UserName, Email = model.EmailAddress, FirstName = model.FirstName,
                                    LastName = model.LastName };
            var result = userManager.Create(user, model.Password);
            userManager.AddToRole(user.Id, model.UserRole);
                  
            return RedirectToAction("GetUsers", "Manage");

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


            user.Email = model.EmailAddress;
            user.UserName = user.UserName;

            userManager.Update(user);

            return RedirectToAction("GetUsers", "Manage");
        }


        public ActionResult Delete(string id)
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

            return RedirectToAction("GetUsers", "Manage");
        }
    }
}
