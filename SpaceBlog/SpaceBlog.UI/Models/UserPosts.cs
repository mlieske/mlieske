using Microsoft.AspNet.Identity.EntityFramework;
using SpaceBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpaceBlog.UI.Models
{
    public class UserPosts
    {
        public virtual IdentityUser User { get; set; }
        public virtual Post Post { get; set; }

        public UserPosts()
        {

        }

        public UserPosts(IEnumerable<Post> posts, IEnumerable<IdentityUser> users)
        {
            Users = users;
            Posts = posts;
        }

        public IEnumerable<Post> Posts;
        public IEnumerable<IdentityUser> Users;
    }
}