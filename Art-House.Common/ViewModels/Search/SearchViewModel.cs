using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Common.ViewModels.Search
{
    public class SearchViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<PostText> PostTexts { get; set; }
    }
}
