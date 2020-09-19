﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            CreatedTime = DateTime.Now;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImg { get; set; }
        public string BackGroundImg { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsDeleted { get; set; }
        //relations
        public virtual IEnumerable<userAnswer> UserAnswers { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        public virtual IEnumerable<likePost> LikePosts { get; set; }
        public virtual IEnumerable<SavePost> SavePosts { get; set; }
        public virtual IEnumerable<PostText> PostTexts { get; set; }
        public virtual IEnumerable<UserInUser> UserInUsers { get; set; }
        public virtual IEnumerable<Offers> Offers { get; set; }
    }
}