using SpaceBlog.Data;
using SpaceBlog.Models;
using SpaceBlog.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpaceBlog.UI.Controllers
{
    [RoutePrefix("api")]
    public class SearchAPIController : ApiController
    {
        [Route("getPostsByTag/{tagName}")]
        public IHttpActionResult GetByTag(string tagName)
        {
           
            var repo = RepositoryFactory.Create();
            var posts = repo.GetPostByTag(tagName);
            posts = posts.Where(p => p.ApprovalStatus).ToList();
            if(posts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(posts);
            }
            
        }

        [Route("getPostsByTitle/{postTitle}")]
        public IHttpActionResult GetByTitle(string postTitle)
        {

            var repo = RepositoryFactory.Create();
            var posts = repo.GetPostByTitle(postTitle);
            posts = posts.Where(p => p.ApprovalStatus).ToList();

            if (posts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(posts);
            }

        }

        [Route("getPostsByUser/{userName}")]
        public IHttpActionResult GetByUser(string userName)
        {

            var repo = RepositoryFactory.Create();
            var context = new SpaceBlogDbContext();


            if (context.Users.Any(u => u.UserName == userName))
            {
                var userId = context.Users.FirstOrDefault(u => u.UserName == userName).Id;

                var posts = repo.GetPostsByUser(userId);

                if (posts == null)
                {
                    return NotFound();
                }

                else
                {
                    return Ok(posts);
                }
            }
            else
                return NotFound();

        }
    }
}
