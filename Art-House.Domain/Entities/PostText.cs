using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class PostText : BaseEntity<string>
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
        [MaxLength(60,ErrorMessage ="نمی تواند بیشتر 60 حروف باشد")]
        public string Name { get; set; }
        [MaxLength(250,ErrorMessage ="نمی تواند بیتشر از 250 حروف باشد")]
        [MinLength(25,ErrorMessage ="نمی تواندی کمتر 25 حروف باشد")]
        [Required(ErrorMessage ="نمی تواند کمتر از 25 حروف و بیشتر از 250 تا باشد")]
        public string ShortText { get; set; }
        [Required(ErrorMessage = "نمی تواند خالی باشد")]
        public string Text { get; set; }
        public ulong Visit { get; set; }
        //relations
        [ForeignKey("GroupId")]
        public virtual Groups Groups { get; set; }
        [ForeignKey("UserId")]
        public virtual User Users { get; set; }
        public List<SavePost> SavePosts { get; set; }
        public List<PostTextVisit> PostTextVisits { get; set; }
        public List<Comment> Comments { get; set; }
        public List<likePost> likePost { get; set; }
    }
}
