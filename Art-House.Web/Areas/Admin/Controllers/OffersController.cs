using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Common.ViewModels.Questions;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
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
            var getAll = (await _db.OffersRepository.GetAllAsync());
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

        //نظر سنجی
        public async Task<IActionResult> Questions()
        {
            var getAll = await _db.QuestionsRepository.GetAllAsync();
            var viewmodel = new AddQuestionViewModel()
            {
                Question = getAll,
            };
            return View(viewmodel);
        }

        //افزودن سوال
        [HttpPost]
        [AjaxOnly]
        public async Task<ActionResult> AddQuestion(string text, string isDeleted, string startPoll, string endPoll)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(isDeleted) && !string.IsNullOrEmpty(endPoll)
                && !string.IsNullOrEmpty(startPoll))
            {
                var startPollConvert = Convert.ToDateTime(startPoll);
                var endPollConvert = Convert.ToDateTime(endPoll);

                var TimestartPoll = _db.QuestionsRepository.Where(p => p.StartThePoll.Date <= startPollConvert && p.EndThePoll >= startPollConvert).ToList();
                var TimeEndPoll = _db.QuestionsRepository.Where(p => p.StartThePoll.Date <= endPollConvert && p.EndThePoll >= endPollConvert).ToList();
                if (TimestartPoll.Count != 0 || TimeEndPoll.Count != 0)
                {
                    ViewBag.Error = "در این زمان نظر سنجی موجود است";
                    return Json(ViewBag.Error);
                }
                var question = new Question()
                {
                    QuestionText = text,
                    IsDeleted = isDeleted == "حذف شده",
                    CreatedTime = DateTime.Now,
                    StartThePoll = startPollConvert,
                    EndThePoll = endPollConvert
                };
                await _db.QuestionsRepository.InsertAsync(question);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"سوال  با موفقیت ساخته شد.");
                return Json(question);
            }
            _notification.AddErrorToastMessage("نام و وضعیت نمی تواند خالی باشد");
            return Json(null);
        }

        //گرفتن ایدی سوال
        [AjaxOnly]
        [HttpPost]
        public async Task<ActionResult> GetQuestionById(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var question = await _db.QuestionsRepository.GetByIdAsync(id);
                return Json(question);
            }
            _notification.AddErrorToastMessage("دوباره امتحان کنید");
            return Json(null);
        }
      
        //.یرایش سوال
        [AjaxOnly]
        [HttpPost]
        public ActionResult UpdateQuestion(string id, string text, string isDeleted, string startPoll, string endPoll)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(isDeleted) && !string.IsNullOrEmpty(endPoll)
                && !string.IsNullOrEmpty(startPoll))
            {
                var startPollConvert = Convert.ToDateTime(startPoll);
                var endPollConvert = Convert.ToDateTime(endPoll);

                var TimestartPoll = _db.QuestionsRepository.Where(p => p.StartThePoll.Date <= startPollConvert && p.EndThePoll >= startPollConvert).ToList();
                var TimeEndPoll = _db.QuestionsRepository.Where(p => p.StartThePoll.Date <= endPollConvert && p.EndThePoll >= endPollConvert).ToList();
                if (TimestartPoll.Count != 0 || TimeEndPoll.Count != 0)
                {
                    ViewBag.Error = "در این زمان نظر سنجی موجود است";
                    return Json(ViewBag.Error);
                }
                var question = _db.QuestionsRepository.GetById(id);
                question.IsDeleted = isDeleted == "حذف شده";
                question.QuestionText = text;
                question.LastModifiedTime = DateTime.Now;
                _db.QuestionsRepository.Update(question);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"سوال  با موفقیت ویرایش شد.");
                return Json(question);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }

        //حذف سوال
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteQuestion(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var question = _db.QuestionsRepository.GetById(id);
                var btnQuestion = _db.BtnQuestionRepository.Where(p => p.QuestionId == question.Id).ToList();
                if (btnQuestion.Count != 0)
                {
                    foreach(var item in btnQuestion)
                    {
                        _db.BtnQuestionRepository.Delete(item);
                    }
                }
                _db.QuestionsRepository.Delete(question);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"سوال  با موفقیت حذف شد.");
                return Json(question);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }
        //ساختن دکمه
        [HttpPost]
        public async Task<IActionResult> AddBtnQuestions(AddQuestionViewModel model,string questionId)
        {
            if (model.BtnQuestion.Any())
            {
                foreach(var item in model.BtnQuestion)
                {
                    var btnQuedtion = new BtnQuestion()
                    {
                        Name = item.Name,
                        QuestionId = questionId,
                        CreatedTime = DateTime.Now,
                    };
                   await _db.BtnQuestionRepository.InsertAsync(btnQuedtion);
                }
                await _db.SaveChangeAsync();
                _notification.AddSuccessToastMessage("با موفقیت دکمه ها به سوال اضافه شد");
                return RedirectToRoute("/Admin/Offers/Questions");
            }
            return View();
        }

    }
}
