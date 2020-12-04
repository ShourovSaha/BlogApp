using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Data.Entity;
using BlogApp.Data.Repository;

namespace BlogApp.Data.Repository
{
    public class PostRepository : Repository<Post, int, BlogAppDBContext>, IPostRepository
    {
        public PostRepository(BlogAppDBContext dBContext) : base(dBContext)
        {
        }



        public async Task<List<Post>> GetDataDynamically(string searchedText, int numberOfRowsToShow, int pageIndex)
        {
            List<Post> data = null;

            if (String.IsNullOrEmpty(searchedText))
            {
                data = await _context.Posts.Include(i =>i.Comments)
                                     .Skip<Post>(numberOfRowsToShow * (pageIndex - 1))
                                     .Take<Post>(numberOfRowsToShow).ToListAsync();
            }
            else
            {
                data = await _context.Posts.Include(i => i.Comments)
                                     .Where(p => p.Title == searchedText)
                                     .Skip<Post>(numberOfRowsToShow * (pageIndex - 1))
                                     .Take<Post>(numberOfRowsToShow).ToListAsync();
            }
            return data;
        }
    }
}
