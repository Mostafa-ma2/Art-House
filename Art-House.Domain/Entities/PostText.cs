using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class PostText:BaseEntity<string>
    {
        public PostText()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string UserId { get; set; }
        public string Image { get; set; }
        public string GroupId { get; set; }
        public string Name { get; set; }
        public string ShortText { get; set; }
        public string Text { get; set; }
        public ulong Visit { get; set; }
        //relations
        [ForeignKey("GroupId")]
        public virtual Groups Groups { get; set; }
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
        public  List<SavePost> SavePosts { get; set; }
        public List<PostTextVisit> PostTextVisits { get; set; }
        public List<Comment> Comments { get; set; }
        public List<likePost> likePost { get; set; }
    }
}
