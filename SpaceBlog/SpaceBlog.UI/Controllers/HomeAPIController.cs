using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SpaceBlog.Data;

namespace SpaceBlog.UI.Controllers
{
    [RoutePrefix("api")]
    public class HomeAPIController : ApiController
    {

        [Route("PostsByTag/{tagName}")]
        public IHttpActionResult GetByTag(string tagName)
        {

            var repo = RepositoryFactory.Create();
            var posts = repo.GetPostByTag(tagName);
            if (posts == null)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }

        }
    }
}
