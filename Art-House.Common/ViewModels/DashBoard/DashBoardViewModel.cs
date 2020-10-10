using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Common.ViewModels.DashBoard
{
   public class DashBoardViewModel
    {
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<PostText> postTexts { get; set; }
        public IEnumerable<Offers> offers { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}
