using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Common;
using BlogApp.Data.Repository;
using BlogApp.Data.UnitOfWorks;

namespace BlogApp.Data.UnitOfWorks
{
    public class BlogAppUOW : UnitOfWork, IBlogAppUOW
    {
        BlogAppDBContext _bdContext;
        public IPostRepository PostRepository { get; set; }
        public ICommectRepository CommectRepository { get; set; }

        public BlogAppUOW(BlogAppDBContext dBContext, IPostRepository postRepository, ICommectRepository commectRepository) : base(dBContext)
        {
            _bdContext = dBContext;
            PostRepository = postRepository;
            CommectRepository = commectRepository;
        }
    }
}
