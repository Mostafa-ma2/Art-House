using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class Comment : BaseEntity<string>
    {
        public Comment()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public string PostId { get; set; }
        public string text { get; set; }
        public string ParentID { get; set; }
        //relations
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
        [ForeignKey("PostId")]
        public virtual PostText PostTexts { get; set; }

    }
}
