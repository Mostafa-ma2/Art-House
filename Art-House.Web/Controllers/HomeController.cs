using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Art_House.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Art_House.Data.Interfaces;
using System.Security.Claims;

namespace Art_House.Web.Controllers
{
    public class HomeController : Controller
    {
        //صفحه اصلی
        #region ctor
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db)
        {
            _logger = logger;
            _db = db;
        }
        #endregion

        //Get
        [HttpGet]
        public IActionResult Index(int pageId=1)
        {
            ViewBag.PageID = pageId;
            var getall = _db.PostTextRepository.GetAll();
            ViewBag.CountPage = getall.Count()/3;
            var Post = _db.PostTextRepository.Paging(pageId, 5);
            var userId= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            //foreach (var item in Post)
            //{
            //    item.Users.UserInUsers = _db.UserInUserRepository.Where(p => p.user == item.UserId&&p.UserId== userId).ToList();
            //}
            return View(Post);
        }
    }
}
