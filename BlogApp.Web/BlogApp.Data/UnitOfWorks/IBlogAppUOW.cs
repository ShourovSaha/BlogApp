using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Common;
using BlogApp.Data.Repository;

namespace BlogApp.Data.UnitOfWorks
{
    public interface IBlogAppUOW : IUnitOfWork
    {
        IPostRepository PostRepository { get; set; }
        ICommectRepository CommectRepository { get; set; }
    }
}
