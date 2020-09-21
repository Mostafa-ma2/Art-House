using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Art_House.Common.ViewModels.Account;
using Art_House.Domain.Entities;
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
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _notification;
        private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<User> userManager, ILogger<AccountController> logger,
           SignInManager<User> signInManager, IToastNotification notification)
        {
            _userManager = userManager;
            _notification = notification;
            _signInManager = signInManager;
            _logger = logger;
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
                    Email = model.Email
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

                    return RedirectToAction("Index", "Home");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
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
