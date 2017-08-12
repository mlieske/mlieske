using SpaceBlog.Data;
using SpaceBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpaceBlog.UI.Controllers
{
    [RoutePrefix("api")]
    public class PostAPIController : ApiController
    {
        [Route("addTag/{tagName}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddTag(string tagName)
        {
            var repo = RepositoryFactory.Create();
            var tags = repo.GetAllTags();
            var tag = new Tag();
            tag.TagName = tagName;

            if (!tags.Any(t => t.TagName == tagName))
            {
                //tag.TagId = tags.Count() + 1;
                tag.Posts = new List<Post>();
                repo.InsertTag(tag);
                tags = repo.GetAllTags();
                return Ok(tags);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
