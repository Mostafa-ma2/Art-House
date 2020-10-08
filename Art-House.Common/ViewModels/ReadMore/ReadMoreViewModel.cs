using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Common.ViewModels.ReadMore
{
    public class ReadMoreViewModel
    {
        public IEnumerable<Comment> Comments { get; set; }
        public Comment Comment { get; set; }
        public PostText PostText { get; set; }
    }
}
