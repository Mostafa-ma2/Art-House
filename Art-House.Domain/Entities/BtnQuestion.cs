using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_House.Domain.Entities
{
    public class BtnQuestion:BaseEntity<string>
    {
        //دکمه های نظرسنجی
        public BtnQuestion()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string Name { get; set; }
        public string QuestionId { get; set; }
        //relations
        public virtual IEnumerable<userAnswer>  UserAnswers{ get; set; }
        [ForeignKey("QuestionId")]
        public Question  Questions{ get; set; }

    }
}
