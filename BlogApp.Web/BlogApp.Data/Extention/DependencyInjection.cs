using BlogApp.Data.Repository;
using BlogApp.Data.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Extention
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogAppDBContext>(option => option.UseSqlServer(configuration.GetConnectionString("dbConnStr")));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommectRepository, CommentRepository>();
            services.AddScoped<IBlogAppUOW, BlogAppUOW>();
        }
    }
}
