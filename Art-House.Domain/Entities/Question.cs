using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class Question:BaseEntity<string>
    {
        //برای گرفتن نظر سنجی
        public Question()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string QuestionText { get; set; }
        public DateTime StartThePoll { get; set; }
        public DateTime EndThePoll { get; set; }

        //relations
        public List<BtnQuestion> BtnQuestions { get; set; }
        public List<userAnswer> userAnswers { get; set; }

    }
}
