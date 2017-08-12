using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpaceBlog.Models
{
    public class StaticPage
    {
        public int StaticPageId { get; set; }
        public string StaticPageTitle { get; set; }
        [AllowHtml]
        public string StaticPageBody { get; set; }
        public string ImageFileName { get; set; }
        
    }
}
