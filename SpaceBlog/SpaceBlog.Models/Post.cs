using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace SpaceBlog.Models
{
    public class Post
    {
        public int PostId { get; set; }
        [AllowHtml]
        public string PostBody { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string ImageFileName { get; set; }
        public string PostTitle { get; set; }
        public string UserId { get; set; }
        public bool ApprovalStatus { get; set; }

        public virtual ICollection<Tag> Tags {get; set;}

        public Post()
        {
            CreationDate = DateTime.Now;
        }
    }
}
