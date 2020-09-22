﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Data.Interfaces;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        #region ctor
        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        private readonly IFileManager _fileManager;
        public PostController(IUnitOfWork db, IToastNotification notification, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _notification = notification;

            _fileManager = new FileManager(webHostEnvironment.WebRootPath);
        }
        #endregion


        //Get
        [HttpGet]
        public async Task<IActionResult>  Index()
        {
            var GetAllPost = (await _db.PostTextRepository.GetAllAsync());
            return View(GetAllPost);
        }
        //گرفتن ایدی 
        [AjaxOnly]
        [HttpPost]
        public async Task<IActionResult> GetPostTextById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var PostTextId = await _db.PostTextRepository.GetByIdAsync(id);
            return Json(PostTextId);
        }

        //حذف پست
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeletePostText(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var postText = _db.PostTextRepository.GetById(id);
                if (postText.Image != null)
                {
                    _fileManager.DeleteImage(postText.Image, FileManagerType.FileType.PostTextImages);
                }
                _db.PostTextRepository.Delete(postText);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"پلتفرم {postText.Name} با موفقیت حذف شد.");
                return Json(postText);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }
    }
}
