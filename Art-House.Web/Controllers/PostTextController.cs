using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.ViewModels.PostTexts;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Controllers
{
    [Authorize]
    public class PostTextController : Controller
    {
        //ساختن و ویرایش پست
        #region ctor
        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        private readonly IFileManager _fileManager;
        public PostTextController(IUnitOfWork db, IToastNotification notification, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _notification = notification;

            _fileManager = new FileManager(webHostEnvironment.WebRootPath);
        }
        #endregion

        //get
        [HttpGet]
        public async Task<IActionResult> AddPost()
        {
            return View(new AddPostTextViewModel
            {
                groups = (await _db.GroupRepository.GetAllAsync(a => !a.IsDeleted))
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost(AddPostTextViewModel model, IFormFile image)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.postText.Name) || string.IsNullOrEmpty(model.postText.ShortText)
             || string.IsNullOrEmpty(model.postText.Text))
            {
                _notification.AddWarningToastMessage("لطفا مقادیر را به درستی پر کنید");
                return RedirectToAction(nameof(AddPost));
            }
            if (image != null)
                model.postText.Image = await _fileManager.UploadImage(image, FileManagerType.FileType.GameImage);
            var PostText = new PostText()
            {
                GroupId = model.postText.Groups.Id,
                Image = model.postText.Image,
                Name = model.postText.Name,
                ShortText = model.postText.ShortText,
                Text = model.postText.Text,
                CreatedTime = DateTime.Now,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Groups = model.postText.Groups
            };
            await _db.PostTextRepository.InsertAsync(PostText);
            await _db.SaveChangeAsync();
            _notification.AddSuccessToastMessage("با موفقیت انجام شد");
            return RedirectToAction("Index","Home");
        }
    }
}
