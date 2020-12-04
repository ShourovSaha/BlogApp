using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entity;

namespace BlogApp.Data.Repository
{
    public interface IPostRepository : IRepository<Post, int, BlogAppDBContext>
    {
        Task<List<Post>> GetDataDynamically(string searchedText, int numberOfRowsToShow, int pageIndex);
    }
}
