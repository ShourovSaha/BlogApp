using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public int CommentCount { get; set; }

        public List<CommentViewModel> Comments { get; set; } = new List<CommentViewModel>();
    }

    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime Created { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}
