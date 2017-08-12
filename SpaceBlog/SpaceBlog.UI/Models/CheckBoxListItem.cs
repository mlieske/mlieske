using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlog.UI.Models
{
    public class CheckBoxListItem
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool IsChecked { get; set; }
    }
}
