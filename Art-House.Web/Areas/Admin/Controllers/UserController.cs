﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Common.ViewModels.Users;
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

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //مدیریت کاربران
        #region ctor
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _notification;
        private readonly IFileManager _fileManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IToastNotification notification,
             IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _notification = notification;
            _fileManager = new FileManager(webHostEnvironment.WebRootPath);

        }
        #endregion

        //Get
        [HttpGet]
        public IActionResult Index()
        {
            var getAllUser = _userManager.Users.ToList();
            return View(getAllUser);
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
                PhoonNumber=user.PhoneNumber,
                ProfileImg=user.ProfileImg,
                Bio=user.Bio,
                userId = user.Id
            };
            return View(User);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(UserEditViewModel model, IFormFile image)
        {
            if (string.IsNullOrEmpty(model.userId))
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
                    SetErrors(resetPassResult);
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
                      FileManagerType.FileType.PostTextImages);
                }
            }
            user.ProfileImg = model.ProfileImg;
            user.Bio = model.Bio;
            user.PhoneNumber = model.PhoonNumber;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                return Json(user);
            }
            _notification.AddErrorToastMessage("دوباره امتحان کنید");
            return Json(null);
        }

        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var user = await _userManager.FindByIdAsync(id);
                await _userManager.DeleteAsync(user);
                _notification.AddSuccessToastMessage($"پلتفرم {user.UserName} با موفقیت حذف شد.");
                return Json(user);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }

        [HttpGet]
        [Route("/Admin/User/AddToRole/userId={userId}")]
        public async Task<IActionResult> AddToRole(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return RedirectToAction("Home", "Index");
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return RedirectToAction(nameof(Index));

            await _userManager.AddToRoleAsync(user, "Admin");
            _notification.AddSuccessToastMessage("کاربر  به درجه Admin ارتقا یافت");

            return RedirectToAction("Index", "Home");
        }

        #region Helper
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }

            return Json("ایمیل وارد شده از قبل موجود است");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return Json(true);
            }

            return Json("این نام کاربری از قبل موجود است");
        }

        public void SetErrors(IdentityResult results)
        {
            foreach (var item in results.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        #endregion
    }
}
