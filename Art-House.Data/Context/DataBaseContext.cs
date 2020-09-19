using Art_House.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Art_House.Data.Context
{
    public class DataBaseContext : IdentityDbContext
    {
        public DataBaseContext()
        {

        }
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=Art-HouseDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<User> User { get; set; }
        public DbSet<Asnwer> Asnwer { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<likePost> likePosts { get; set; }
        public DbSet<SavePost> SavePosts { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<PostText> PostText { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<userAnswer> UserAnswer { get; set; }
        public DbSet<UserInUser> UserInUser { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
