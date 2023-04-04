using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.EF
{
    public class ImageSocialDbContext : DbContext
    {
        public ImageSocialDbContext(DbContextOptions<ImageSocialDbContext> options) : base(options)
        {
            
        }

        public DbSet<Entities.ImageEntity> Images { get; set; }
        public DbSet<Entities.PostEntity> Posts { get; set; }
        public DbSet<Entities.UserEntity> Users { get; set; }
        public DbSet<Entities.AccountEntity> Accounts { get; set; }
        public DbSet<Entities.CommentEntity> Comments { get; set; }
        public DbSet<Entities.LikeEntity> Likes { get; set; }
        public DbSet<Entities.FollowerEntity> Followers { get; set; }
        public DbSet<Entities.FollowingEntity> Followings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserEntity>().HasOne(a => a.Account).WithOne(u => u.User);

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    UserID = 1,
                    UserName = "admin",
                    
                }
            );

            modelBuilder.Entity<AccountEntity>().HasData(
                new AccountEntity
                {
                    AcountID = 1,
                    UserId = 1,
                    Username = "admin",
                    Password = "admin",
                    Role = "Admin"
                }
            );
        }
    }
}
