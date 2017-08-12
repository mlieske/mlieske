using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceBlog.Models;

namespace SpaceBlog.Data.Interfaces
{
    public interface ISpaceBlogRepository
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetApprovedPosts();
        IEnumerable<Tag> GetAllTags();
        IEnumerable<StaticPage> GetAllStaticPages();

        IEnumerable<Post> GetPostByTag(string tagName);
        IEnumerable<Post> GetPostByTitle(string postTitle);
        IEnumerable<Post> GetPostsByUser(string userName);

        Post GetPostById(int postId);
        Tag GetTagByName(string tagName);
        Tag GetTagById(int tagId);
        StaticPage GetStaticPageById(int pageId);

        void EditPost(Post post);
        void EditTag(Tag tag);
        void EditStaticPage(StaticPage staticpage);
        void SetPostToApproved(int id);

        void DeletePost(int postId);
        void DeleteTag(int tagId);
        void DeleteStaticPage(int staticpageId);

        void InsertPost(Post post);
        void InsertTag(Tag tag);
        void InsertStaticPage(StaticPage staticpage);

        // most popular tags used
        IEnumerable<Tag> GetTopTenTags();

    }
}
