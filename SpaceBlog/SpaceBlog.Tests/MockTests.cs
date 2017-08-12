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
    class MockTests
    {
        //[SetUp]
        //public void Init()
        //{
        //    var repo = new MockRepository();

        //    var postReset = repo.GetAllPosts();

        //}
        [Test]
        public void CanGetAllPosts()
        {
            var repo = new MockRepository();

            var posts = repo.GetAllPosts();

            Assert.AreEqual(7, posts.Count());
            Assert.AreEqual(0, posts.ElementAt(0).PostId);
            Assert.AreEqual("OMG", posts.ElementAt(0).PostTitle);
        }
        [Test]
        public void CanGetAllTags()
        {
            var repo = new MockRepository();

            var tags = repo.GetAllTags();

            Assert.AreEqual(5, tags.Count());
            Assert.AreEqual(2, tags.ElementAt(1).TagId);
            Assert.AreEqual("#Post", tags.ElementAt(1).TagName);
        }
        [Test]
        public void CanGetAllStaticPages()
        {
            var repo = new MockRepository();

            var staticPages = repo.GetAllStaticPages();

            Assert.AreEqual(4, staticPages.Count());
            Assert.AreEqual(3, staticPages.ElementAt(2).StaticPageId);
            Assert.AreEqual("Static Page Title 3", staticPages.ElementAt(2).StaticPageTitle);
        }
        [Test]
        public void CanInsertPost()
        {
            var repo = new MockRepository();
            var allPosts = repo.GetAllPosts();
            var newPost = new Post
            {
                ApprovalStatus = false,
                PostId = 7,
                PostBody = "Body text for a brand new post!",
                PostTitle = "New Test Title 7",
                CreationDate = DateTime.Now,
                ExpirationDate = DateTime.ParseExact("12/1/2018", "MM/d/yyyy", CultureInfo.InvariantCulture),
                ImageFileName = "~/Images/placholder.jpg",
                UserId = "1",
            };
            

            
            repo.InsertPost(newPost);



            Assert.AreEqual(8, allPosts.Count());
            Assert.AreEqual(7, allPosts.ElementAt(7).PostId);
            Assert.AreEqual("Example Post Title 2", allPosts.ElementAt(2).PostTitle);
        }

        [Test]
        public void CanGetByTagName()
        {
            var repo = new MockRepository();

            var PostsByTag = repo.GetPostByTag("#Excellent");

            Assert.AreEqual(3, PostsByTag.Count());
            //Assert.AreEqual(3, staticPages.ElementAt(2).StaticPageId);
            //Assert.AreEqual("Static Page Title 3", staticPages.ElementAt(2).StaticPageTitle);
        }

        [Test]
        public void CanGetByPostId()
        {
            var repo = new MockRepository();

            var PostsById = repo.GetPostById(2);

            Assert.AreEqual("Example Post Title 2", PostsById.PostTitle);
            //Assert.AreEqual("Static Page Title 3", staticPages.ElementAt(2).StaticPageTitle);
        }

        [Test]
        public void CanGetTagByName()
        {
            var repo = new MockRepository();

            var tagByName = repo.GetTagByName("#Excellent");

            Assert.AreEqual(1, tagByName.TagId);
            //Assert.AreEqual("Static Page Title 3", staticPages.ElementAt(2).StaticPageTitle);
        }

        [Test]
        public void CanGetTopTenTags()
        {
            var repo = new MockRepository();

            IEnumerable<Tag> taglist = repo.GetTopTenTags();

            Assert.AreEqual(1, taglist.First().TagId);
            Assert.AreEqual(3, taglist.ElementAt(1).TagId);
            Assert.AreEqual(2, taglist.ElementAt(2).TagId);
            Assert.AreEqual(4, taglist.ElementAt(3).TagId);
            Assert.AreEqual(5, taglist.Last().TagId);

        }

        [Test]
        public void CanGetApprovedPosts()
        {
            var repo = new MockRepository();
            var posts = repo.GetApprovedPosts();
            foreach(Post p in posts)
            {
                Assert.True(p.ApprovalStatus);
            }
        }
    }
}
