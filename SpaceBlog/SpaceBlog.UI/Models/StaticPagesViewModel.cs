using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaceBlog.Models;

namespace SpaceBlog.UI.Models
{
    public class StaticPagesViewModel
    {
        [AllowHtml]
        public StaticPage StaticPagetoView { get; set; }

        public bool StaticPageExists { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

    }
}