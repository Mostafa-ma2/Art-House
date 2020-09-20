using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        #region ctor

        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        public DashBoardController(IUnitOfWork db, IToastNotification notification)
        {
            _db = db;
            _notification = notification;
        }
        #endregion

        //Get
        [HttpGet]
        public IActionResult Index()
        {
             return View();
        }
    }
}
