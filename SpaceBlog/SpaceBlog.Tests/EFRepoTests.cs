using NUnit.Framework;
using SpaceBlog.Data.Repositories;
using SpaceBlog.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceBlog.Tests
{
    [TestFixture]
    public class EFRepoTests
    {
        [Test]
        public void CanGetAllPostsEF()
        {
            var repo = new EntityFrameworkRepo();
            var posts = repo.GetAllPosts();

            // Assert.AreEqual(6, posts.Count());
        }


        [Test]
        public void CanInsertPostEF()
        {
            var repo = new EntityFrameworkRepo();

            int count = repo.GetAllPosts().Count();

            var newPost = new Post
            {
                ApprovalStatus = false,
                PostBody = "Body text for a brand new post!",
                PostTitle = "New Test Title 13",
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.ParseExact("12/1/2018", "MM/d/yyyy", CultureInfo.InvariantCulture),
                ImageFileName = "~/Images/placholder.jpg",
                UserId = "1",
                Tags = new List<Tag>() { repo.GetAllTags().FirstOrDefault(t => t.TagId == 1) }
            };
            repo.InsertPost(newPost);

            var allPosts = repo.GetAllPosts();
            Assert.AreEqual(count + 1, allPosts.Count());
            
        }

   
    }
}
