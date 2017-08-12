using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBlog.Data.Interfaces;
using SpaceBlog.Models;
using System.Data.Entity;

namespace SpaceBlog.Data.Repositories
{
    public class EntityFrameworkRepo : ISpaceBlogRepository
    {
        public void DeletePost(int postId)
        {
            var repository = new DbContextEntities();
            var post = repository.Posts.FirstOrDefault(p => p.PostId == postId);

            if(post != null)
            {
                repository.Posts.Remove(post);
                repository.SaveChanges();
            }
        }

        public void DeleteStaticPage(int staticpageId)
        {
            var repository = new DbContextEntities();
            var staticPage = repository.StaticPages.FirstOrDefault(sp => sp.StaticPageId == staticpageId);

            if (staticPage != null)
            {
                repository.StaticPages.Remove(staticPage);
                repository.SaveChanges();
            }
        }

        public void DeleteTag(int tagId)
        {
            var repository = new DbContextEntities();
            var tag = repository.Tags.FirstOrDefault(t => t.TagId == tagId);

            if (tag != null)
            {
                repository.Tags.Remove(tag);
                repository.SaveChanges();
            }
        }

        public void EditPost(Post post)
        {
            var repo = new DbContextEntities();

            // get post from current DB context
            Post postFromcurrentContext = repo.Posts.Include("Tags").First(p => p.PostId == post.PostId);

            // update the post
            postFromcurrentContext.ImageFileName = post.ImageFileName;
            postFromcurrentContext.ExpirationDate = post.ExpirationDate;
            postFromcurrentContext.ApprovalStatus = post.ApprovalStatus;
            postFromcurrentContext.CreationDate = post.CreationDate;
            postFromcurrentContext.PostBody = post.PostBody;
            postFromcurrentContext.UserId = post.UserId;
            postFromcurrentContext.PostTitle = post.PostTitle;

            List<Tag> tagsFromCurrentContext =
                  repo.Tags.ToList().Where(
                  t => post.Tags.Any(
                  t2 => t2.TagId == t.TagId
            )).ToList();

            postFromcurrentContext.Tags = null;
            postFromcurrentContext.Tags = tagsFromCurrentContext;
          
            repo.Entry(postFromcurrentContext).State = EntityState.Modified;

            repo.SaveChanges();
        }

        public void SetPostToApproved(int id)
        {
            var repository = new DbContextEntities();
            var found = repository.Posts.FirstOrDefault(p => p.PostId == id);
            found.ApprovalStatus = true;
            repository.Entry(found).State = EntityState.Modified;
            repository.SaveChanges();
        }


        public void EditStaticPage(StaticPage staticpage)
        {
            var repository = new DbContextEntities();
            repository.Entry(staticpage).State = EntityState.Modified;
            repository.SaveChanges();

        }

        public void EditTag(Tag tag)
        {
            var repository = new DbContextEntities();

            repository.Entry(tag).State = EntityState.Modified;
            repository.SaveChanges();
        }

        //public void RemoveTags(int id)
        //{
        //    var repository = new DbContextEntities();
        //    var allTags = GetAllTags();
        //    repository.Tags.Remove()
        //}

        public IEnumerable<Post> GetAllPosts()
        {
            var repository = new DbContextEntities();
            return (repository.Posts.ToList());
        }

        public IEnumerable<StaticPage> GetAllStaticPages()
        {
            var repository = new DbContextEntities();
            return (repository.StaticPages.ToList());
        }

        public IEnumerable<Tag> GetAllTags()
        {
            var repository = new DbContextEntities();
            return (repository.Tags.ToList());
        }

        public Post GetPostById(int postId)
        {
            var repo = new DbContextEntities();
            Post  post = repo.Posts.FirstOrDefault(p => p.PostId == postId);
            return post;
        }

        public IEnumerable<Post> GetPostByTag(string tagName)
        {
            var repo = new DbContextEntities();
            return(repo.Posts.Include("Tags").ToList().Where(p => p.Tags.Any(t => t.TagName.ToLower() == tagName.ToLower())));
        }

        public Tag GetTagByName(string tagName)
        {
            var repo = new DbContextEntities();
            return(repo.Tags.FirstOrDefault(t => t.TagName == tagName));
        }

        public Tag GetTagById(int tagId)
        {
            var repo = new DbContextEntities();
            return (repo.Tags.FirstOrDefault(t => t.TagId == tagId));
        }

        public StaticPage GetStaticPageById(int pageId)
        {
            var repo = new DbContextEntities();
            return (repo.StaticPages.FirstOrDefault(s => s.StaticPageId == pageId));
        }


        public void InsertPost(Post post)
        {
            var repo = new DbContextEntities();

            List<Tag> tagsFromCurrentContext = 
                repo.Tags.ToList().Where(
                    t => post.Tags.Any(
                        t2 => t2.TagId == t.TagId
                        )).ToList();

            post.Tags = tagsFromCurrentContext;
            repo.Posts.Add(post);
            repo.SaveChanges();
        }

        public void InsertStaticPage(StaticPage staticpage)
        {
            var repo = new DbContextEntities();

            repo.StaticPages.Add(staticpage);
            repo.SaveChanges();
        }


        public void InsertTag(Tag tag)
        {
            var repo = new DbContextEntities();
            repo.Tags.Add(tag);
            repo.SaveChanges();
        }

        public IEnumerable<Tag> GetTopTenTags()
        {
            var repo = new DbContextEntities();
            var tags = repo.Tags.OrderByDescending(t => t.Posts.Count()).Take(10);
            return tags;
        }

        public IEnumerable<Post> GetApprovedPosts()
        {
            var repo = new DbContextEntities();

            return repo.Posts.Where(p => p.ApprovalStatus == true);
        }

        public IEnumerable<Post> GetPostByTitle(string postTitle)
        {
            var repo = new DbContextEntities();

            return repo.Posts.ToList().Where(p => p.PostTitle.ToLower().Contains(postTitle.ToLower()));
        }

        public IEnumerable<Post> GetPostsByUser(string userId)
        {
            var repo = new DbContextEntities();
            return repo.Posts.ToList().Where(p => p.UserId.ToLower() == userId.ToLower());
        }
    }
}
