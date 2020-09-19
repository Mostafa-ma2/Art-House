using EzGame.Domain.Core.Services;
using EzGame.Domain.Core.Services.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Art_House.Domain.Entities
{
    public class Groups:BaseEntity<string>
    {
        public Groups()
        {
            CreatedTime = DateTime.Now;
            Id = IdGenerator.NewGuid();
            LastModifiedTime = DateTime.Now;
        }
        public string Name { get; set; }
        public int subset { get; set; }
        //ralations
        public virtual IEnumerable<PostText> PostTexts{ get; set; }

    }
}
