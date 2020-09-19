﻿using Art_House.Domain.Entities;
using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_House.Domain.Entities
{
    public class userAnswer:BaseEntity<string>
    {
        //گرفتن تعداد
        public userAnswer()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public string AsnwerId { get; set; }
        //relastion
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("AsnwerId")]
        public virtual Asnwer Asnwer { get; set; }

    }
}
