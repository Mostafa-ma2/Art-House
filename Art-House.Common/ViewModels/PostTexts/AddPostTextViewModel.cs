using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Common.ViewModels.PostTexts
{
    public class AddPostTextViewModel
    {
        public PostText postText { get; set; }
        public IEnumerable<Groups> groups { get; set; }
    }
}
