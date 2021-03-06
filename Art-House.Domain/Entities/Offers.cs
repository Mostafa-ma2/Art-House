﻿using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Art_House.Domain.Entities
{
    public class Offers:BaseEntity<string>
    {
        public Offers()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string UserId { get; set; }
        [MinLength(10, ErrorMessage = "نمی تواندی کمتر 10 حروف باشد")]
        public string OffersText { get; set; }
        //reltions
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }

    }
}
