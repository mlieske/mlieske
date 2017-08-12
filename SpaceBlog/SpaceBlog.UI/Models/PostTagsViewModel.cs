using SpaceBlog.Models;
using SpaceBlog.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SpaceBlog.UI.Models
{
    public class PostTagsViewModel
    {
        [AllowHtml]
        public Post PostToView { get; set; }

        public List<CheckBoxListItem> AllTags { get; set; }

        public bool PostExists { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public PostTagsViewModel()
        {
            AllTags = new List<CheckBoxListItem>();
        }

        //public PostTagsViewModel(Post post, IEnumerable<Tag> allTags)
        //{
        //    PostToView = post;
        //    AllTags = new List<CheckBoxListItem>();
        //}

    }
}
