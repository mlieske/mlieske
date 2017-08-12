using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlog.Models.ViewModels
{
    public class ListTopTagsViewModel
    {

        public ListTopTagsViewModel()
        {
            
        }

        public ListTopTagsViewModel(IEnumerable<Tag> tags, IEnumerable<Post> post)
        {
            Tags = tags;
            Posts = post;
            
            


        }

        public IEnumerable<Tag> Tags;
        public IEnumerable<Post> Posts;

    }


}
