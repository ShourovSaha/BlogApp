using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data.Entity;
using BlogApp.Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Web.Controllers
{
    public class CommentsController : BaseController
    {
        IBlogAppUOW _uow;
        public CommentsController(IBlogAppUOW uow)
        {
            _uow = uow;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> LikeCommect(int? id)
        {
            if (id == null)
            {
                return Json(false);
            }

            var comment = await _uow.CommectRepository.GetById((int)id);

            if (comment == null)
            {
                return Json(false);
            }

            comment.Like += 1;

            _uow.CommectRepository.Update(comment);
            await _uow.Save();

            return Json(true);
        }


        public async Task<JsonResult> DislikeCommect(int? id)
        {
            if (id == null)
            {
                return Json(false);
            }

            var comment = await _uow.CommectRepository.GetById((int)id);

            if (comment == null)
            {
                return Json(false);
            }

            comment.Like -= 1;

            _uow.CommectRepository.Update(comment);
            await _uow.Save();

            return Json(true);
        }
    }
}