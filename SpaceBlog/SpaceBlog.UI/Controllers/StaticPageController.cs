using Microsoft.AspNet.Identity;
using SpaceBlog.Data;
using SpaceBlog.Data.Interfaces;
using SpaceBlog.Models;
using SpaceBlog.Models.ViewModels;
using SpaceBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace SpaceBlog.UI.Controllers
{
    public class StaticPageController : Controller
    {
        private ISpaceBlogRepository _SpaceBlogRepo;

        public StaticPageController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: StaticPage

        [HttpGet]
        public ActionResult Index(int id)
        {
            var model = _SpaceBlogRepo.GetStaticPageById(id);

            
            return View(model);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _SpaceBlogRepo.GetStaticPageById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(StaticPage page)
        {
            _SpaceBlogRepo.DeleteStaticPage(page.StaticPageId);
            return RedirectToAction("Pages", "Manage");
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StaticPagesViewModel();
            viewModel.StaticPageExists = false;

            return View("Index",viewModel);
        }

        [HttpPost]
        public ActionResult Add(StaticPagesViewModel staticpage)
        {
            if (staticpage.ImageUpload != null && staticpage.ImageUpload.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Website IMAGES");

                string fileName = Path.GetFileNameWithoutExtension(staticpage.ImageUpload.FileName);
                string extension = Path.GetExtension(staticpage.ImageUpload.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                staticpage.ImageUpload.SaveAs(filePath);
                staticpage.StaticPagetoView.ImageFileName = Path.GetFileName(filePath);

            }
            
            _SpaceBlogRepo.InsertStaticPage(staticpage.StaticPagetoView);
            return RedirectToAction("Pages", "Manage");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var onestatic = _SpaceBlogRepo.GetStaticPageById(id);
            var viewmodel = new StaticPagesViewModel();

            viewmodel.StaticPagetoView = onestatic;
            viewmodel.StaticPageExists = true;

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(StaticPagesViewModel staticpage)
        {
            if (staticpage.ImageUpload != null && staticpage.ImageUpload.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Website IMAGES");

                string fileName = Path.GetFileNameWithoutExtension(staticpage.ImageUpload.FileName);
                string extension = Path.GetExtension(staticpage.ImageUpload.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                staticpage.ImageUpload.SaveAs(filePath);
                staticpage.StaticPagetoView.ImageFileName = Path.GetFileName(filePath);

            }
            _SpaceBlogRepo.EditStaticPage(staticpage.StaticPagetoView);
            return RedirectToAction("Pages", "Manage");
        }

        public ActionResult List()
        {
            var model = _SpaceBlogRepo.GetAllStaticPages();
            return View(model);
        }

        public ActionResult SPView(int id)
        {
            var model = _SpaceBlogRepo.GetStaticPageById(id);
            return View(model);
        }

    }
}