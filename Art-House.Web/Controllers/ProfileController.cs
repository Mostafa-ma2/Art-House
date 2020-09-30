using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
            GetUser.PostTexts = _db.PostTextRepository.Where(p => p.UserId == GetUser.Id).ToList();
            return View(GetUser);
            
        }
    }
}
