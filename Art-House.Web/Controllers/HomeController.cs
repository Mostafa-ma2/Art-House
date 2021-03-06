﻿using System;
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
using Art_House.Common.ViewModels.Search;
using Art_House.Domain.Entities;
using NToastNotify;
using Art_House.Common.Filters.ActionFilters;

namespace Art_House.Web.Controllers
{
    public class HomeController : Controller
    {
        //صفحه اصلی
        #region ctor
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork db, IToastNotification notification)
        {
            _logger = logger;
            _db = db;
            _notification = notification;
        }
        #endregion

        //Get
        [HttpGet]
        public IActionResult Index(int pageId = 1)
        {
            ViewBag.PageID = pageId;
            var getall = _db.PostTextRepository.GetAll();
            var count = getall.Count() / 5;
            if (getall.Count() % 5 != 0)
            {
                ViewBag.CountPage = count + 1;
            }
            else
            {
                ViewBag.CountPage = count;
            }
            var Post = _db.PostTextRepository.Paging(pageId, 5);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            //foreach (var item in Post)
            //{Data is Null.
            //    item.Users.UserInUsers = _db.UserInUserRepository.Where(p => p.user == item.UserId&&p.UserId== userId).ToList();
            //}
            return View(Post);
        }

        //سرچ
        [HttpGet]
        public IActionResult Search(string text, string group, int pageId = 1)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            if (!string.IsNullOrEmpty(text))
            {
                var Post = _db.PostTextRepository.Where(p => p.Name.Contains(text) ||
                p.ShortText.Contains(text)).OrderByDescending(p => p.CreatedTime).ToList();
                var User = _db.UserRepository.Where(p => p.UserName.Contains(text)).ToList();
                var viemodel = new SearchViewModel()
                {
                    PostTexts = Post,
                    Users = User
                };
                return View(viemodel);
            }
            if (!string.IsNullOrEmpty(group))
            {
                var Post = _db.PostTextRepository.Where(p => p.Groups.Name == group).OrderByDescending(p => p.CreatedTime).ToList();
                var User = _db.UserRepository.Where(p => p.UserName.Contains(group)).ToList();
                ViewBag.PageID = pageId;
                var count = Post.Count() / 5;
                if (Post.Count() % 5 != 0)
                {
                    ViewBag.CountPage = count + 1;
                }
                else
                {
                    ViewBag.CountPage = count;
                }
                var Posts = _db.PostTextRepository.Paging(pageId, 5, Post);
                ViewBag.group = group;
                var viemodel = new SearchViewModel()
                {
                    PostTexts = Posts,
                    Users = User

                };
                return View(viemodel);
            }
            _notification.AddWarningToastMessage("چیزی وارد نکردید");
            return RedirectToAction(nameof(Index));
        }

        //پیشنهاد ها
        [HttpGet]
        public IActionResult Offers()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            return View();
        }

        //افزودن پیشنهاد
        [HttpPost]
        public async Task<IActionResult> AddOffers(Offers model)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            if (string.IsNullOrEmpty(model.OffersText))
            {
                _notification.AddErrorToastMessage("مقادیر را پر کنید");
                ViewBag.Error = "پیشنهاد نمی تواند خالی باشد";
                return View("Offers", model);
            }
            var offers = new Offers()
            {
                OffersText = model.OffersText,
                UserId = userId,
                CreatedTime = DateTime.Now
            };
            await _db.OffersRepository.InsertAsync(offers);
            await _db.SaveChangeAsync();
            _notification.AddSuccessToastMessage("پیشنهاد شما ثبت شد");
            ViewBag.Success = "<h2 style='text - align: center; padding: 10px; background: #1b1be1a6; color: white;border-radius: 10px;'>پیشنهاد شما ثبت شد با تشکر</h2>";
            return View("Offers");
        }

        // گرفتن درصد برای نظر سنجی
        [HttpGet]
        [Route("/Home/GetPercentage/BtnId={BtnId}/questionId={questionId}")]
        public async Task<IActionResult> GetPercentage(string BtnId, string questionId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            if (!string.IsNullOrEmpty(BtnId)&&!string.IsNullOrEmpty(questionId))
            {
                var userAsnwer = _db.UserAnswerRepository.Where(p => p.UserId == userId && p.QuestionId== questionId).ToList();
                if(userAsnwer.Count == 0)
                {
                    var addUserAsnwer = new userAnswer()
                    {
                        UserId = userId,
                        QuestionId = questionId,
                        BtnQuestionId = BtnId
                    };
                    await _db.UserAnswerRepository.InsertAsync(addUserAsnwer);
                    await _db.SaveChangeAsync();
                    _notification.AddSuccessToastMessage("نظر شما ثبت شد");
                    return Redirect("/");
                }
            }
            _notification.AddWarningToastMessage("شما قبلا نظر دادید");
            return Redirect("/");
        }

    }
}
