using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Art_House.Common.ViewModels.Account
{
    public class EditProfileViewModel
    {
        public string PofileImg { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
    }
}
