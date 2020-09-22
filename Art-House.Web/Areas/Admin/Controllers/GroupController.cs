using System;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GroupController : Controller
    {
        //مدیریت گروها
        #region ctor

        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        public GroupController(IUnitOfWork db, IToastNotification notification)
        {
            _db = db;
            _notification = notification;
        }
        #endregion

        //نمایش تمام گروها
        //Get 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var GetGroup = (await _db.GroupRepository.GetAllAsync(a=>!a.IsDeleted));
            return View(GetGroup);
        }

        //افزودن گروه
        [HttpPost]
        [AjaxOnly]
        public async Task<ActionResult> AddGroup(string title, string isDeleted)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(isDeleted))
            {
                var Group = new Groups()
                {
                    Name = title,
                    IsDeleted = isDeleted == "حذف شده",
                    CreatedTime = DateTime.Now,
                    LastModifiedTime = DateTime.Now
                };
                await _db.GroupRepository.InsertAsync(Group);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"پلتفرم {title} با موفقیت ساخته شد.");
                return Json(Group);
            }
            _notification.AddErrorToastMessage("نام و وضعیت نمی تواند خالی باشد");
            return Json(null);
        }

        //گرفتن ایدی گروه
        [AjaxOnly]
        [HttpPost]
        public async Task<ActionResult> GetGroupById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Group = await _db.GroupRepository.GetByIdAsync(id);
                return Json(Group);
            }
            _notification.AddErrorToastMessage("دوباره امتحان کنید");
            return Json(null);
        }
        
        //.یرایش گروه
        [AjaxOnly]
        [HttpPost]
        public ActionResult UpdateGroup(string id, string title, string isDeleted)
        {
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(isDeleted))
            {
                var Group = _db.GroupRepository.GetById(id);
                Group.IsDeleted = isDeleted == "حذف شده";
                Group.Name = title;
                Group.LastModifiedTime = DateTime.Now;
                _db.GroupRepository.Update(Group);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"پلتفرم {title} با موفقیت ویرایش شد.");
                return Json(Group);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }

        //حذف گروه
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteGroup(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Group = _db.GroupRepository.GetById(id);
                _db.GroupRepository.Delete(Group);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"پلتفرم {Group.Name} با موفقیت حذف شد.");
                return Json(Group);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }
    }
}
