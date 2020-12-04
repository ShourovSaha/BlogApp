using BlogApp.Data.Entity;
using BlogApp.Data.Extention;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data
{
    public class BlogAppDBContext : DbContext
    {
        public BlogAppDBContext(DbContextOptions<BlogAppDBContext> options) : base(options)
        { }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Seed();
        }
    }
}
