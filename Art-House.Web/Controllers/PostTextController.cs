using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.Extensions;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Common.ViewModels.PostTexts;
using Art_House.Common.ViewModels.ReadMore;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Art_House.Web.Controllers
{
    public class PostTextController : Controller
    {
        //ساختن و ویرایش پست
        #region ctor
        private readonly IUnitOfWork _db;
        private readonly IToastNotification _notification;
        private readonly IFileManager _fileManager;
        public PostTextController(IUnitOfWork db, IToastNotification notification, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _notification = notification;

            _fileManager = new FileManager(webHostEnvironment.WebRootPath);
        }
        #endregion

        //get
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> AddPost()
        {
            ViewBag.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View(new AddPostTextViewModel
            {
                groups = (await _db.GroupRepository.GetAllAsync(a => !a.IsDeleted))
            });
        }
        //افزودن
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> AddPost(AddPostTextViewModel model, IFormFile image)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.postText.ShortText)
             || string.IsNullOrEmpty(model.postText.Text))
            {
                _notification.AddWarningToastMessage("لطفا مقادیر را به درستی پر کنید");
                return RedirectToAction(nameof(AddPost));
            }
            if (image != null)
                model.postText.Image = await _fileManager.UploadImage(image, FileManagerType.FileType.PostTextImages);
            var group = _db.GroupRepository.GetAll().FirstOrDefault(a => a.Name == model.postText.Groups.Name);
            var PostText = new PostText()
            {
                GroupId = group.Id,
                Image = model.postText.Image,
                Name = model.postText.Name,
                ShortText = model.postText.ShortText,
                Text = model.postText.Text,
                CreatedTime = DateTime.Now,
                UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                Groups = group
            };
            await _db.PostTextRepository.InsertAsync(PostText);
            await _db.SaveChangeAsync();
            _notification.AddSuccessToastMessage("با موفقیت انجام شد");
            return RedirectToAction("Index", "Home");
        }

        //ویرایش
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditPostText(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var viewModel = new AddPostTextViewModel()
            {
                groups = (await _db.GroupRepository.GetAllAsync()),
                postText = (await _db.PostTextRepository.GetByIdAsync(id))
            };
            ViewBag.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> EditPostText(AddPostTextViewModel model, IFormFile image)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(model.postText.ShortText)
            || string.IsNullOrEmpty(model.postText.Text))
            {
                _notification.AddWarningToastMessage("لطفا مقادیر را به درستی پر کنید");
                return RedirectToAction("Index","Profile",new { id=model.postText.UserId});
            }
            var postText = (await _db.PostTextRepository.GetByIdAsync(model.postText.Id));
            if (image == null)
            {
                model.postText.Image = postText.Image;
            }
            else
            {
                if (image.FileName != postText.Image && postText.Image != null)
                {
                    _fileManager.DeleteImage(postText.Image, FileManagerType.FileType.PostTextImages);
                    model.postText.Image = await _fileManager.UploadImage(image,
                        FileManagerType.FileType.PostTextImages);
                }
                if (postText.Image == null)
                {
                    model.postText.Image = await _fileManager.UploadImage(image,
                      FileManagerType.FileType.PostTextImages);
                }
            }
            var group = _db.GroupRepository.GetAll().FirstOrDefault(a => a.Name == model.postText.Groups.Name);
            postText.GroupId = group.Id;
            postText.Groups = group;
            postText.Name = model.postText.Name;
            postText.Image = model.postText.Image;
            postText.ShortText = model.postText.ShortText;
            postText.Text = model.postText.Text;
            _db.PostTextRepository.Update(postText);
            _db.SaveChange();
            _notification.AddSuccessToastMessage("با موفقیت ویرایش شد");
            return RedirectToAction("Index", "Profile", new { id = model.postText.UserId });
        }


        //گرفتن ایدی 
        [AjaxOnly]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetPostTextById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var PostTextId = await _db.PostTextRepository.GetByIdAsync(id);
            return Json(PostTextId);
        }

        //حذف پست
        [AjaxOnly]
        [HttpPost]
        [Authorize]
        public ActionResult DeletePostText(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var postText = _db.PostTextRepository.GetById(id);
                if (postText.Image != null)
                {
                    _fileManager.DeleteImage(postText.Image, FileManagerType.FileType.PostTextImages);
                }
                var GetSavePost = _db.SavePostRepository.Where(p => p.PostTextId == postText.Id).ToList();
                foreach(var iten in GetSavePost)
                {
                    _db.SavePostRepository.Delete(iten);
                }
                var GetPostVisit = _db.PostTextVisitRepository.Where(p => p.PostId == postText.Id).ToList();
                foreach (var iten in GetPostVisit)
                {
                    _db.PostTextVisitRepository.Delete(iten);
                }
                _db.PostTextRepository.Delete(postText);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($" {postText.Name} با موفقیت حذف شد.");
                return Json(postText);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }

        //سیو کردن پست برای کاربر
        [AjaxOnly]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddSavePost(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {

                var AddPost = new SavePost()
                {
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    PostTextId = id,
                    CreatedTime = DateTime.Now
                };
                await _db.SavePostRepository.InsertAsync(AddPost);
                await _db.SaveChangeAsync();
                _notification.AddSuccessToastMessage($"با موفقیت سیو شد");
                return Json(AddPost);
            }
            _notification.AddErrorToastMessage("پست را نمی توانیم پیدا کنیم");
            return Json(null);
        }

        //گرفتن ایدی savePost
        [AjaxOnly]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetSavePostById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var SavePostId = await _db.SavePostRepository.GetByIdAsync(id);
            return Json(SavePostId);
        }

        //حذف پست
        [AjaxOnly]
        [HttpPost]
        [Authorize]
        public ActionResult DeleteSavePost(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var SavePost = _db.SavePostRepository.GetById(id);
                _db.SavePostRepository.Delete(SavePost);
                _db.SaveChange();
                _notification.AddSuccessToastMessage("با موفقیت سیو شد");
                return Json(SavePost);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }
        


        //ادامه مطلب
        [HttpGet]
        public async Task<IActionResult> ReadMore(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var Post = await _db.PostTextRepository.GetByIdAsync(id);
            var userId= User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.UserId = userId;
            var savepost = _db.SavePostRepository.Where(p => p.UserId == userId).ToList();
            ViewBag.UserCount = savepost.Count();
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            Post.Groups =await _db.GroupRepository.GetByIdAsync(Post.GroupId);
            Post.Users = await _db.UserRepository.GetByIdAsync(Post.UserId);
            var GetVisit = _db.PostTextVisitRepository.Where(p => p.PostId == id && p.Ip == ip).ToList();
            if(GetVisit.Count == 0)
            {
                var visit = new PostTextVisit()
                {
                    Ip = ip,
                    PostId = id
                };
                await _db.PostTextVisitRepository.InsertAsync(visit);
                Post.Visit += 1;
                _db.PostTextRepository.Update(Post);
                _db.SaveChange();
            }
            var Comments = _db.CommentRepository.Where(p => p.PostId == Post.Id).OrderByDescending(p=>p.CreatedTime).ToList();
            if (Comments != null)
            {
                foreach(var item in Comments)
                {
                    item.Users =await _db.UserRepository.GetByIdAsync(item.UserId);
                }
            }
            var viewModel = new ReadMoreViewModel()
            {
                PostText = Post,
                Comments = Comments
            };
            return View(viewModel);
        }
        
        //افزودن کامنت
        [HttpPost]
        public async Task<IActionResult> AddComment(ReadMoreViewModel model)
        {
            if (string.IsNullOrEmpty(model.Comment.text))
            {
                _notification.AddWarningToastMessage("لطفا مقادیر را پر کنید");
                return RedirectToAction("PostText", "ReadMore",model.Comment.PostId);
            }
            if (model.Comment.ParentID == null)
            {
                var comment = new Comment()
                {
                    PostId = model.Comment.PostId,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    text = model.Comment.text,
                    CreatedTime = DateTime.Now
                };
                await _db.CommentRepository.InsertAsync(comment);
            }
            else
            {
                var comment = new Comment()
                {
                    PostId = model.Comment.PostId,
                    UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
                    text = model.Comment.text,
                    CreatedTime = DateTime.Now,
                    ParentID=model.Comment.ParentID
                };
                await _db.CommentRepository.InsertAsync(comment);
            }
            await _db.SaveChangeAsync();
            _notification.AddSuccessToastMessage("نظر شما ثبت شد");
            return RedirectToAction("ReadMore", "PostText", new { id=model.Comment.PostId });
        }


        //حذف کامنت
        [HttpGet]
        public ActionResult DeleteComment(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var Comment = _db.CommentRepository.GetById(id);
                var commentParentId = _db.CommentRepository.Where(p => p.ParentID == Comment.Id).ToList();
                if (Comment.ParentID == null)
                {
                    foreach(var item in commentParentId)
                    {
                        _db.CommentRepository.Delete(item);
                    }
                }
                _db.CommentRepository.Delete(Comment);
                _db.SaveChange();
                return RedirectToAction("ReadMore", "PostText", new { id = Comment.PostId });
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return RedirectToAction("Home", "Index");
        }

    }
}
