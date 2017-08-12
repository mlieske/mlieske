using SpaceBlog.Data;
using SpaceBlog.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlog.UI.Controllers
{
    public class SearchController : Controller
    {
        private ISpaceBlogRepository _SpaceBlogRepo;

        public SearchController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: Search
        [HttpGet]
        public ActionResult Index()
        {
            
            var model = _SpaceBlogRepo.GetAllPosts();
            model = model.Where(m => m.ApprovalStatus).ToList();
            return View(model);
        }

        //[HttpGet]
        //public ActionResult PostId(int id)
        //{
        //    var model = _SpaceBlogRepo.GetPostById(id);
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult PostTag(string id)
        {
            var model = _SpaceBlogRepo.GetPostByTag(id);
            return View(model);
        }

        //[HttpGet]
        //public ActionResult Tag(string id)
        //{
        //    var model = _SpaceBlogRepo.GetTagByName(id);
        //    return View(model);
        //}

        //[HttpGet]
        //public ActionResult Tags()
        //{
        //    var model = _SpaceBlogRepo.GetAllTags();
        //    return View(model);
        //}

    }
}