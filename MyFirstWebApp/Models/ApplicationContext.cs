using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstWebApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPost>()
                .HasKey(q =>
                new
                { q.UserId, q.PostId }
                );
            modelBuilder.Entity<UserPost>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.UsersWhoLiked)
                .HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<UserPost>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.FavoritePosts)
                .HasForeignKey(pt => pt.UserId);
        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
            if (!Posts.Any())
            {
                Posts.AddRange(
                new Post
                {
                    Title = "My first Post!",
                    ShortDesc = "I will tell u about my new post",
                    LongDesc = "It wal really long history about..........." + Guid.NewGuid().ToString().Substring(0, 20),
                    Images = new List<Image> { new Image { Path = "/Photos/photo1.jpg" }, new Image { Path = "/Photos/NoImage.png" }, new Image { Path = "/Photos/photo1.jpg" }, new Image { Path = "/Photos/NoImage.png" } },
                    User = new User { FirstName = "Tom" }

                },
                new Post
                {
                    Title = "My second Post!",
                    ShortDesc = "I will tell u about my newest post",
                    LongDesc = "It was really long history about...........ABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCD" + Guid.NewGuid().ToString().Substring(0, 25),
                    User = new User { FirstName = "Bob" }
                },
                new Post
                {
                    Title = "My 3th Post!",
                    ShortDesc = "None",
                    LongDesc = "CDABCDABCDABCDABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDAABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCDABCD" + Guid.NewGuid().ToString().Substring(0, 25),
                    User = new User { FirstName = "Alex" }
                });
                SaveChanges();
            }

        }
    }
}
