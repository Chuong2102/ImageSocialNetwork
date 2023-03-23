using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
