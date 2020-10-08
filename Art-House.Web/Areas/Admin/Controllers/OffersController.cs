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
    public class OffersController : Controller
    {
        //بخش ارتباط با کاربران
        #region ctor

        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        public OffersController(IUnitOfWork db, IToastNotification notification)
        {
            _db = db;
            _notification = notification;
        }
        #endregion

        //Get
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var getAll =(await _db.OffersRepository.GetAllAsync());
            return View(getAll);
        }

        //گرفتن ایدی 
        [AjaxOnly]
        [HttpPost]
        public async Task<IActionResult> GetOffersById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پیشنهاد مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Index");
            }
            var offers = await _db.OffersRepository.GetByIdAsync(id);
            return Json(offers);
        }

        //حذف پست
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteOffers(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var offers = _db.OffersRepository.GetById(id);
                _db.OffersRepository.Delete(offers);
                _db.SaveChange();
                return Json(offers);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }

    }
}
