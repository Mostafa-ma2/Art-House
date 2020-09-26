using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
   public class PostTextVisit:BaseEntity<string>
    {
        public PostTextVisit()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string Ip { get; set; }
        public string PostId { get; set; }

        //relations

        [ForeignKey("PostId")]
        public virtual PostText PostText { get; set; }
    }
}
