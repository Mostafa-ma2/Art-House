using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.ComponentModel.DataAnnotations;
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
        //relations
        public virtual Asnwer Asnwer { get; set; }

    }
}
