using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        //مدیریت کامنت ها
        #region ctor

        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        public CommentController(IUnitOfWork db, IToastNotification notification)
        {
            _db = db;
            _notification = notification;
        }
        #endregion

        //Get
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var GetAll = await _db.CommentRepository.GetAllAsync();
            return View(GetAll);
        }

        //گرفتن ایدی savePost
        [AjaxOnly]
        [HttpPost]
        public async Task<IActionResult> GetCommentById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("کامنت مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Index");
            }
            var comment = await _db.CommentRepository.GetByIdAsync(id);
            return Json(comment);
        }

        //حذف پست
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteComment(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var comment = _db.CommentRepository.GetById(id);
                var commentParentId = _db.CommentRepository.Where(p => p.ParentID == comment.Id).ToList();
                if (comment.ParentID == null)
                {
                    foreach (var item in commentParentId)
                    {
                        _db.CommentRepository.Delete(item);
                    }
                }
                _db.CommentRepository.Delete(comment);
                _db.SaveChange();
                return Json(comment);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }


    }
}
