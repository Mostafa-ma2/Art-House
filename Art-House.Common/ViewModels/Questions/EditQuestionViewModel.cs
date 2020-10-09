using Art_House.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Common.ViewModels.Questions
{
    public class EditQuestionViewModel
    {
        public Question Question { get; set; }
        public IEnumerable<BtnQuestion> BtnQuestion { get; set; }
    }
}
