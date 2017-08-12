using SpaceBlog.Data;
using SpaceBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SpaceBlog.Models;
using SpaceBlog.Models.ViewModels;
using SpaceBlog.UI.Models;


namespace SpaceBlog.UI.Controllers
{
    public class HomeController : Controller
    {
        private ISpaceBlogRepository _SpaceBlogRepo;

        public HomeController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            var model = new ListTopTagsViewModel();
            model.Tags = _SpaceBlogRepo.GetTopTenTags();

            model.Posts = _SpaceBlogRepo.GetAllPosts();
            model.Posts = model.Posts.Where(p => p.ApprovalStatus).ToList();
            return View( model); //casted a list of posts to model. Simple fix to the error it was running when just returning model..
        }

        [HttpGet]
        public ActionResult About()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ContactUs()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
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
    }
}