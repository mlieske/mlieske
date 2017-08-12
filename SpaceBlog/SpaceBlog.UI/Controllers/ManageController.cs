using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SpaceBlog.Data;
using SpaceBlog.Data.Interfaces;
using SpaceBlog.Models.ViewModels;
using SpaceBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlog.UI.Controllers
{
    public class ManageController : Controller
    {
        private ISpaceBlogRepository _SpaceBlogRepo;

        public ManageController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: Manage
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Pages()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                var model = _SpaceBlogRepo.GetAllStaticPages();
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Posts()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                var model = _SpaceBlogRepo.GetAllPosts();
                return View(model);
            }
            else if (User.Identity.IsAuthenticated && User.IsInRole("contributor"))
            {
                
                var model = _SpaceBlogRepo.GetAllPosts().Where(p => p.UserId.ToString() == User.Identity.GetUserId());
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                var context = new SpaceBlogDbContext();
                return View(context.Users);
            }
            else
            {
                return RedirectToAction("Index","Home");
            }

        }
    }
}