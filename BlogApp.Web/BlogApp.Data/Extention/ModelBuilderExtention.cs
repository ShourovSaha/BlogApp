using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Data.Entity;

namespace BlogApp.Data.Extention
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<Post>().HasMany<Comment>(a => a.Comments).WithOne();


            builder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Post 1", UserName = "Admin", Created = DateTime.UtcNow },
                new Post { Id = 2, Title = "Post 2", UserName = "Admin", Created = DateTime.UtcNow },
                new Post { Id = 3, Title = "Post 3", UserName = "Admin", Created = DateTime.UtcNow },
                new Post { Id = 4, Title = "Post 4", UserName = "User 1", Created = DateTime.UtcNow },
                new Post { Id = 5, Title = "Post 5", UserName = "User 2", Created = DateTime.UtcNow },
                new Post { Id = 6, Title = "Post 6", UserName = "User 3", Created = DateTime.UtcNow }
                );

            builder.Entity<Comment>().HasData(
                new Comment { Id = 1, Text = "Test comment.", UserName = "User 1", Like = 12, Dislike = 3, PostId = 1, Created = DateTime.UtcNow },
                new Comment { Id = 2, Text = "Test comment.", UserName = "User 2", Like = 10, Dislike = 5, PostId = 3, Created = DateTime.UtcNow },
                new Comment { Id = 3, Text = "Test comment.", UserName = "User 3", Like = 7, Dislike = 1, PostId = 2, Created = DateTime.UtcNow },
                new Comment { Id = 4, Text = "Test comment.", UserName = "Admin", Like = 14, Dislike = 2, PostId = 3, Created = DateTime.UtcNow },
                new Comment { Id = 5, Text = "Test comment.", UserName = "User 1", Like = 2, Dislike = 2, PostId = 5, Created = DateTime.UtcNow },
                new Comment { Id = 6, Text = "Test comment.", UserName = "Admin", Like = 5, Dislike = 1, PostId = 6, Created = DateTime.UtcNow }
                );
        }
    }
}
