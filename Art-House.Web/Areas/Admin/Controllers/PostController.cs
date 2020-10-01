using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Data.Interfaces;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class PostController : Controller
    {
        // مدیریت پست
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
      
    }
}
