using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlog.Models
{
    public class PostTagList
    {
        [Key, Column(Order = 0)]
        public int PostId { get; set; }
        [Key, Column(Order = 1)]
        public int TagId { get; set; }
    }
}
