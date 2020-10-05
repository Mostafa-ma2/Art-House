using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.ViewModels.Users;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Controllers
{
    public class ProfileController : Controller
    {
        //پروفایل 
        #region ctor
        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        private readonly UserManager<User> _userManager;
        private readonly IFileManager _fileManager;
        public ProfileController(IUnitOfWork db, IToastNotification notification,UserManager<User> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _notification = notification;
            _userManager = userManager;
            _fileManager = new FileManager(webHostEnvironment.WebRootPath);
        }
        #endregion

        //Get
        [HttpGet]
        [Route("/Profile/{id}")]
        public async Task<IActionResult> Index(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("کاربر یات نشد دوبارع امتحان کنید");
                return RedirectToAction("Index", "Home");
            }
            var GetUser =await _db.UserRepository.GetByIdAsync(id);
            if (GetUser == null)
            {
                _notification.AddWarningToastMessage("کاربر یات نشد دوبارع امتحان کنید");
                return RedirectToAction("Index", "Home");
            }
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            GetUser.PostTexts = _db.PostTextRepository.Where(p => p.UserId == GetUser.Id).ToList();
            GetUser.UserInUsers = _db.UserInUserRepository.Where(p => p.user == id).ToList();
            GetUser.SavePosts = _db.SavePostRepository.Where(p => p.UserId == id).ToList();
            foreach(var item in GetUser.UserInUsers)
            {
                if (userId == null)
                {
                    ViewBag.userinuser = 0;
                    return View(GetUser);
                }
                if (item.UserId == userId)
                {
                    ViewBag.userinuser = 1;
                    return View(GetUser);
                }
            }
            foreach(var item in GetUser.SavePosts)
            {
                item.PostTexts = _db.PostTextRepository.GetById(item.PostTextId);
            }
            ViewBag.userinuser = 0;
            return View(GetUser);
        }


        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddErrorToastMessage("کاربر پیدا نشد !");
                return RedirectToAction(nameof(Index));
            }
            var user = (await _userManager.FindByIdAsync(id));
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }
            var User = new UserEditViewModel()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoonNumber = user.PhoneNumber,
                ProfileImg = user.ProfileImg,
                Bio = user.Bio,
                userId = user.Id,
                BackGroundImg = user.BackGroundImg
            };
            return View(User);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserEditViewModel model, IFormFile image, IFormFile backImage)
        {
            if (string.IsNullOrEmpty(model.userId)||string.IsNullOrEmpty(model.UserName)||string.IsNullOrEmpty(model.Email))
            {
                _notification.AddWarningToastMessage("مقادیر را به درستی وارد نمایید");
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.userId);
            if (model.Password != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetPassResult = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (!resetPassResult.Succeeded)
                {
                    return View(model);
                }
            }
            if (image == null)
            {
                model.ProfileImg = user.ProfileImg;
            }
            else
            {
                if (image.FileName != user.ProfileImg && user.ProfileImg != null)
                {
                    _fileManager.DeleteImage(user.ProfileImg, FileManagerType.FileType.ProfileImage);
                    model.ProfileImg = await _fileManager.UploadImage(image,
                        FileManagerType.FileType.ProfileImage);
                }
                if (user.ProfileImg == null)
                {
                    model.ProfileImg = await _fileManager.UploadImage(image,
                      FileManagerType.FileType.ProfileImage);
                }
            }
            if (backImage == null)
            {
                model.BackGroundImg = user.BackGroundImg;
            }
            else
            {
                if (backImage.FileName != user.BackGroundImg && user.BackGroundImg != null)
                {
                    _fileManager.DeleteImage(user.BackGroundImg, FileManagerType.FileType.ProfileImage);
                    model.BackGroundImg = await _fileManager.UploadImage(backImage,
                        FileManagerType.FileType.ProfileImage);
                }
                if (user.BackGroundImg == null)
                {
                    model.BackGroundImg = await _fileManager.UploadImage(backImage,
                      FileManagerType.FileType.ProfileImage);
                }
            }
            user.ProfileImg = model.ProfileImg;
            user.BackGroundImg = model.BackGroundImg;
            user.Bio = model.Bio;
            user.PhoneNumber = model.PhoonNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index","Profile",user.Id);
        }

    }
}
