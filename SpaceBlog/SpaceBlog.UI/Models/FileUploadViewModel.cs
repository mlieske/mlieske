using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBlog.UI.Models
{
    public class FileUploadViewModel
    {
        public HttpPostedFileBase UploadedFile { get; set; }
    }
}