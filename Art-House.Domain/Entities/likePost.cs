using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
   public class likePost:BaseEntity<string>
    {
        //برای گرفتن تعداد لایک پست
        public likePost()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string IP { get; set; }
        public string UserId { get; set; }
        public string PostsId { get; set; }
        //relations
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
        [ForeignKey("PostsId")]
        public virtual PostText PostTexts { get; set; }

    }
}
