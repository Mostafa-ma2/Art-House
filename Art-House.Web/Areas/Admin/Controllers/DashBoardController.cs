using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Art_House.Common.ViewModels.DashBoard;
using Art_House.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
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
        public async Task<IActionResult> Index()
        {
            var getCommentAll = (await _db.CommentRepository.GetAllAsync());
            var getPostTextAll = (await _db.PostTextRepository.GetAllAsync());
            var getOffersAll=(await _db.OffersRepository.GetAllAsync());
            var getUserAll = (await _db.UserRepository.GetAllAsync());
            var viewModel = new DashBoardViewModel()
            {
                comments = getCommentAll,
                postTexts = getPostTextAll,
                offers = getOffersAll,
                Users = getUserAll
            };
             return View(viewModel);
        }
    }
}
