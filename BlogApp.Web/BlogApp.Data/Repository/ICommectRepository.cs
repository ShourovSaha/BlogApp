using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Common;
using BlogApp.Data.Entity;

namespace BlogApp.Data.Repository
{
    public interface ICommectRepository : IRepository<Comment, int, BlogAppDBContext>
    {

    }
}
