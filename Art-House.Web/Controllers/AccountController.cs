using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.Filters.ActionFilters;
using Art_House.Common.ViewModels.Account;
using Art_House.Data.Interfaces;
using Art_House.Domain.Entities;
using Art_House.Domain.Enums;
using Art_House.Services.Interfaces;
using EzGame.Services.FileManager;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration.Utils.Messaging;
using NToastNotify;

namespace Art_House.Web.Controllers
{
    public class AccountController : Controller
    {
        //اکانت ها
        #region ctor
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _db;
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _notification;
        private readonly IFileManager _fileManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger,
           SignInManager<User> signInManager, IToastNotification notification, IWebHostEnvironment webHostEnvironment,
           IUnitOfWork db)
        {
            _db = db;
            _userManager = userManager;
            _notification = notification;
            _signInManager = signInManager;
            _logger = logger;
            _fileManager = new FileManager(webHostEnvironment.WebRootPath);
        }
        #endregion

        //Get
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        //ساخت اکانت
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = model.UserName,
                    CreatedTime = DateTime.Now,
                    Email = model.Email,
                    ProfileImg = "male-user-profile-picture_318-37825.jpg",
                    BackGroundImg= "Disposable-coffee-cup-pen-eyeglasses-spiral-notepad-thumbtack-pins-on-white-background-Top.jpg"
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var emailConfirmationToken =
                        await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var emailMessage =
                        Url.Action("ConfirmEmail", "Account",
                            new { username = user.Email, token = emailConfirmationToken },
                            Request.Scheme);

                    TempData["UserId"] = user.Id;
                    return RedirectToAction("EditProfile", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

            }
            return View(model);
        }


        //ورود
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            ViewData["returnUrl"] = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            model.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
                if (result.Succeeded)
                {
                    _notification.AddSuccessToastMessage("با موفقیت وارد شدید");
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "اکانت شما به دلیل پنج بار ورود ناموفق به مدت پنج دقیقه قفل شده است");
                    return View(model);
                }
                ModelState.AddModelError("", "مقادیر را به درستی وارد کنید");
            }
            else
            {
                ModelState.AddModelError("", "چنین کاربری پیدا نشد");
            }

            return View(model);
        }


        //خروج
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //تکمیل پروفایلل
        [HttpGet]
        public IActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model, IFormFile image)
        {
            if (!ModelState.IsValid)
            {
                _notification.AddWarningToastMessage("نمی توانیم کاربر را پیدا کنیم لطفا وارد اکانت سپس اکانت را ویرایش کنید");
                return RedirectToAction("Index", "Home");
            }
            var Userid = TempData["UserId"];
            var user = await _userManager.FindByIdAsync(Userid.ToString());
            if (user == null)
            {
                _notification.AddWarningToastMessage("نمی توانیم کاربر را پیدا کنیم لطفا وارد اکانت سپس اکانت را ویرایش کنید");
                return RedirectToAction("Index", "Home");
            }
            if (image != null)
            {
                model.PofileImg = await _fileManager.UploadImage(image, FileManagerType.FileType.ProfileImage);
            }
            else
            {
                model.PofileImg = "male-user-profile-picture_318-37825.jpg";
            }
            user.ProfileImg = model.PofileImg;
            user.Bio = model.Bio;
            user.PhoneNumber = model.PhoneNumber;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Home");
        }

        // ارتباط بین کاربران
        [HttpPost]
        [AjaxOnly]
        public async Task<IActionResult> AddCommunicationWithUsers(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var GetUserId=User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(GetUserId))
            {
                _notification.AddWarningToastMessage("کاربر مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var CheckTheConnection = _db.UserInUserRepository.Where(p => p.user == id && p.UserId == GetUserId).ToList();
            if (CheckTheConnection.Count != 0)
            {
                _notification.AddErrorToastMessage("این رابطه وجود دارد");
                return RedirectToAction("Home", "Index");
            }
            var addconnection = new UserInUser()
            {
                user = id,
                UserId = GetUserId
            };
            await _db.UserInUserRepository.InsertAsync(addconnection);
            await _db.SaveChangeAsync();
            return View(addconnection);
        }
        //گرفتن ایدی 
        [AjaxOnly]
        [HttpPost]
        public async Task<IActionResult> GetUserById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                _notification.AddWarningToastMessage("پست مورد نطر یافت نشد دوباره امتحان کنید");
                return RedirectToAction("Home", "Index");
            }
            var UserInUserId = await _db.UserInUserRepository.GetByIdAsync(id);
            return Json(UserInUserId);
        }

        //حذف اتصال کاربر
        [AjaxOnly]
        [HttpPost]
        public ActionResult DeleteCommunicationWithUsers(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var UsrInUser = _db.UserInUserRepository.GetById(id);
                _db.UserInUserRepository.Delete(UsrInUser);
                _db.SaveChange();
                _notification.AddSuccessToastMessage($"پلتفرم {UsrInUser.User.UserName} با موفقیت حذف شد.");
                return Json(UsrInUser);
            }
            _notification.AddErrorToastMessage("مقادیر نمی توانند خالی باشند");
            return Json(null);
        }
        #region Helper
        //ایمیل چک میشه
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return Json(true);
            return Json("ایمیل وارد شده از قبل موجود است");
        }

        //نام کاربری چک میشه

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IsUserNameInUse(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return Json(true);
            return Json("نام کاربری وارد شده از قبل موجود است");
        }



        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userName, string token)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(token))
                return NotFound();
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null) return NotFound();
            var result = await _userManager.ConfirmEmailAsync(user, token);

            return Content(result.Succeeded ? "Email Confirmed" : "Email Not Confirmed");
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account",
                new { ReturnUrl = returnUrl });

            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = null, string remoteError = null)
        {
            returnUrl =
                (returnUrl != null && Url.IsLocalUrl(returnUrl)) ? returnUrl : Url.Content("~/");

            var loginViewModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            };

            if (remoteError != null)
            {
                ModelState.AddModelError("", $"Error : {remoteError}");
                return View("Login", loginViewModel);
            }

            var externalLoginInfo = await _signInManager.GetExternalLoginInfoAsync();
            if (externalLoginInfo == null)
            {
                ModelState.AddModelError("ErrorLoadingExternalLoginInfo", $"مشکلی پیش آمد");
                return View("Login", loginViewModel);
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(externalLoginInfo.LoginProvider,
                externalLoginInfo.ProviderKey, false, true);

            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var email = externalLoginInfo.Principal.FindFirstValue(ClaimTypes.Email);

            if (email != null)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    var userName = email.Split('@')[0];
                    user = new User()
                    {
                        UserName = (userName.Length <= 10 ? userName : userName.Substring(0, 10)),
                        Email = email,
                        EmailConfirmed = true
                    };

                    await _userManager.CreateAsync(user);
                }

                await _userManager.AddLoginAsync(user, externalLoginInfo);
                await _signInManager.SignInAsync(user, false);

                return Redirect(returnUrl);
            }

            ViewBag.ErrorTitle = "لطفا با بخش پشتیبانی تماس بگیرید";
            ViewBag.ErrorMessage = $"دریافت کرد {externalLoginInfo.LoginProvider} نمیتوان اطلاعاتی از";
            return View();
        }
        #endregion
    }
}
