using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Entity;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class BaseController : Controller
    {
        internal List<PostViewModel> populatePostModel(List<Post> postData, List<Comment> commentData)
        {
            List<PostViewModel> posts = new List<PostViewModel>();

            foreach (Post item in postData)
            {
                PostViewModel post = new PostViewModel();

                post.PostId = item.Id;
                post.Title = item.Title;
                post.UserName = item.UserName;
                post.Created = item.Created.ToLocalTime();
                post.CommentCount = item.Comments.Where(c => c.PostId == item.Id).Count();
                post.Comments = item.Comments.Where(c => c.PostId == item.Id)
                                        .Select(a => new CommentViewModel
                                        {
                                            CommentId = a.Id,
                                            Text = a.Text,
                                            UserName = a.UserName,
                                            Created = a.Created,
                                            Like = a.Like,
                                            Dislike = a.Dislike
                                        }).ToList();

                posts.Add(post);
            }

            return posts;
        }

    }
}