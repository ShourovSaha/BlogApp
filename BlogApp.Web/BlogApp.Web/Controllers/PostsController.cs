using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Entity;
using BlogApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Data.UnitOfWorks;

namespace BlogApp.Web.Controllers
{
    public class PostsController : BaseController
    {
        IBlogAppUOW _uow;
        public PostsController(IBlogAppUOW uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index()
        {
            int rowNum = 5; int pageIndex = 0;
            var postData = await _uow.PostRepository.GetDataDynamically("", rowNum, pageIndex);
            var commentData = (List<Comment>)await _uow.CommectRepository.GetAll();
            var result = populatePostModel(postData, commentData);
            return View(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetPosts(string title, int rowNum, int pageIndex)
        {
            var postData = await _uow.PostRepository.GetDataDynamically(title, rowNum, pageIndex);
            var commentData = (List<Comment>)await _uow.CommectRepository.GetAll();
            var result = populatePostModel(postData, commentData);
            return Json(result);
        }

    }
}