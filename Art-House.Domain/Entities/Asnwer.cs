using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;

namespace Art_House.Domain.Entities
{
    public class Asnwer:BaseEntity<string>
    {
        //دکمه های نظرسنجی
        public Asnwer()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public byte Asnwers { get; set; }
        //relations
        public virtual IEnumerable<userAnswer>  UserAnswers{ get; set; }
        public virtual IEnumerable<Question>  Questions{ get; set; }

    }
}
