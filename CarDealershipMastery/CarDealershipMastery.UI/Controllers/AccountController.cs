using CarDealershipMastery.Models.ViewModels;
using CarDealershipMastery.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

namespace CarDealershipMastery.UI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            //attempt to load user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            //user will be null if username or pw bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View(model);
            }
            else
            {
                //successful login, set up cookies and redirect
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authorization = context.Authentication;

            authorization.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }


        public ActionResult ChangePassword()
        {
            throw new NotImplementedException();
        }



    }
}