using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Common;
using BlogApp.Data.Entity;
using BlogApp.Data.Repository;

namespace BlogApp.Data.Repository
{
    public class CommentRepository : Repository<Comment, int, BlogAppDBContext>, ICommectRepository
    {
        public CommentRepository(BlogAppDBContext dBContext) : base(dBContext)
        {}

        
    }
}
