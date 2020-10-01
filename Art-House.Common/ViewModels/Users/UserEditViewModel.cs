using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Art_House.Common.ViewModels.Users
{
    public class UserEditViewModel
    {
        public string userId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "لطفا ایمیل را به درستی وارد نمایید")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "رمز عبوز")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Compare(nameof(Password), ErrorMessage = "گذرواژه و تکرار ان با هم یکسان نیستند")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "تصویر")]

        public string ProfileImg { get; set; }

        [Display(Name = "شمارع تلفن")]
        public string PhoonNumber { get; set; }

        [Display(Name ="درباره کاربر")]
        public string Bio { get; set; }
        public bool IsAdmin { get; set; }
    }
}
