using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
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
        //افزودن
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
                model.postText.Image = await _fileManager.UploadImage(image, FileManagerType.FileType.PostTextImages);
            var group = _db.GroupRepository.GetAll().FirstOrDefault(a=>a.Name==model.postText.Groups.Name);
            var PostText = new PostText()
            {
                GroupId = group.Id,
                Image = model.postText.Image,
                Name = model.postText.Name,
                ShortText = model.postText.ShortText,
                Text = model.postText.Text,
                CreatedTime = DateTime.Now,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Groups = group
            };
            await _db.PostTextRepository.InsertAsync(PostText);
            await _db.SaveChangeAsync();
            _notification.AddSuccessToastMessage("با موفقیت انجام شد");
            return RedirectToAction("Index","Home");
        }

        //ویرایش
        [HttpGet]
        public async Task<IActionResult> EditPostText(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var viewModel = new AddPostTextViewModel()
            {
                groups = (await _db.GroupRepository.GetAllAsync()),
                postText = (await _db.PostTextRepository.GetByIdAsync(id))
            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPostText(AddPostTextViewModel model,IFormFile image)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.postText.Name) || string.IsNullOrEmpty(model.postText.ShortText)
            || string.IsNullOrEmpty(model.postText.Text))
            {
                _notification.AddWarningToastMessage("لطفا مقادیر را به درستی پر کنید");
                return RedirectToAction(nameof(AddPost));
            }
            var postText = (await _db.PostTextRepository.GetByIdAsync(model.postText.Id));
            if (image == null)
            {
                model.postText.Image = postText.Image;
            }
            else
            {
                if (image.FileName != postText.Image && postText.Image!=null)
                {
                    _fileManager.DeleteImage(postText.Image, FileManagerType.FileType.PostTextImages);
                    model.postText.Image = await _fileManager.UploadImage(image,
                        FileManagerType.FileType.PostTextImages);
                }
                if (postText.Image == null)
                {
                    model.postText.Image = await _fileManager.UploadImage(image,
                      FileManagerType.FileType.PostTextImages);
                }
            }
            var group = _db.GroupRepository.GetAll().FirstOrDefault(a => a.Name == model.postText.Groups.Name);
            postText.GroupId = group.Id;
            postText.Groups = group;
            postText.Name = model.postText.Name;
            postText.Image = model.postText.Image;
            postText.ShortText = model.postText.ShortText;
            postText.Text = model.postText.Text;
            _db.PostTextRepository.Update(postText);
            _db.SaveChange();
            _notification.AddSuccessToastMessage("با موفقیت ویرایش شد");
            return RedirectToAction("Home", "Index");
        }
    }
}
