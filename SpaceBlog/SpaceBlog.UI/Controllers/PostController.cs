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
using System.Web;
using System.Web.Mvc;

namespace SpaceBlog.UI.Controllers
{
    public class PostController : Controller
    {

        private ISpaceBlogRepository _SpaceBlogRepo;

        public PostController()
        {
            _SpaceBlogRepo = RepositoryFactory.Create();
        }

        // GET: Post
        [HttpGet]
        public ActionResult Index(int id)
        {
            var model = _SpaceBlogRepo.GetPostById(id);
            return View(model);
        }

        // GET: Post
        //[HttpGet]
        //public ActionResult Post(int id)
        //{
        //    var model = _SpaceBlogRepo.GetPostById(id);
        //    return View(model);
        //}

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new PostTagsViewModel();
            var allTags = _SpaceBlogRepo.GetAllTags().ToList();
            var checkBoxListItems = new List<CheckBoxListItem>();
            viewModel.PostExists = false;

            foreach (var tag in allTags)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                    //We should have already-selected genres be checked
                    IsChecked = false
                });
            }
            viewModel.AllTags = checkBoxListItems;
            return View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Add(PostTagsViewModel post)
        {
            var selectedTagIds = post.AllTags.Where(t => t.IsChecked == true).Select(t => t.TagId).ToList();
            post.PostToView.Tags = new List<Tag>();
            foreach (var tag in selectedTagIds)
            {
                //var selectedTag = _SpaceBlogRepo.GetTagById(tag);
                //post.PostToView.Tags.Add(selectedTag);
                post.PostToView.Tags.Add(_SpaceBlogRepo.GetTagById(tag));
            }

            if (post.ImageUpload != null && post.ImageUpload.ContentLength > 0)
            {
                var savepath = Server.MapPath("~/Website IMAGES");

                string fileName = Path.GetFileNameWithoutExtension(post.ImageUpload.FileName);
                string extension = Path.GetExtension(post.ImageUpload.FileName);

                var filePath = Path.Combine(savepath, fileName + extension);

                int counter = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = Path.Combine(savepath, fileName + counter.ToString() + extension);
                    counter++;
                }

                post.ImageUpload.SaveAs(filePath);
                post.PostToView.ImageFileName = Path.GetFileName(filePath);

            }
            if (User.Identity.IsAuthenticated && User.IsInRole("admin"))
            {
                post.PostToView.ApprovalStatus = true;
            }
            post.PostToView.UserId = User.Identity.GetUserId();
            _SpaceBlogRepo.InsertPost(post.PostToView);
            return RedirectToAction("Posts", "Manage");

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var onePost = _SpaceBlogRepo.GetPostById(id);
            var allTags = _SpaceBlogRepo.GetAllTags().ToList();
            var viewModel = new PostTagsViewModel();
            viewModel.PostToView = onePost;
            var checkBoxListItems = new List<CheckBoxListItem>();
            viewModel.PostExists = true;


            foreach (var tag in allTags)
            {
                checkBoxListItems.Add(new CheckBoxListItem()
                {
                    TagId = tag.TagId,
                    TagName = tag.TagName,
                    //We should have already-selected genres be checked
                    IsChecked = onePost.Tags.Where(x => x.TagId == tag.TagId).Any()
                });
            }
            viewModel.AllTags = checkBoxListItems;

            return View(viewModel);
        }


        [HttpPost]
        public ActionResult Edit(PostTagsViewModel post)
        {
            var selectedTagIds = post.AllTags.Where(t => t.IsChecked == true).Select(t => t.TagId).ToList();
            post.PostToView.Tags = new List<Tag>();



            foreach (var tag in selectedTagIds)
            {
                //var selectedTag = _SpaceBlogRepo.GetTagById(tag);
                //post.PostToView.Tags.Add(selectedTag);
                post.PostToView.Tags.Add(_SpaceBlogRepo.GetTagById(tag));
            }

            _SpaceBlogRepo.EditPost(post.PostToView);
            return RedirectToAction("Posts", "Manage");

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _SpaceBlogRepo.GetPostById(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Post post)
        {
            _SpaceBlogRepo.DeletePost(post.PostId);
            return RedirectToAction("Posts", "Manage");
        }

        [HttpGet]
        public ActionResult Approve(int id)
        {
            _SpaceBlogRepo.SetPostToApproved(id);
            return RedirectToAction("Posts", "Manage");
        }
    }
}