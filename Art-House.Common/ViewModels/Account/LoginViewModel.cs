using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Art_House.Common.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required, Display(Name = "نام کاربری")]
        public string Email { get; set; }

        [Required, Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
