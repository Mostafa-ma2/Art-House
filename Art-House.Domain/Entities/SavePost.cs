using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace Art_House.Domain.Entities
{
    public class SavePost:BaseEntity<string>
    {
        //اتصال بین کاربر و پست برای دخیره سازی ان پست
        public SavePost()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public string PostTextId { get; set; }
        //relations
        [ForeignKey("UserId")]
        public virtual User  User{ get; set; }
        [ForeignKey("PostTextId")]
        public virtual PostText  PostTexts{ get; set; }


    }
}
