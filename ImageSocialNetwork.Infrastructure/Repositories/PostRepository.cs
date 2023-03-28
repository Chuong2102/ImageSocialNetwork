using ImageSocialNetwork.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class PostRepository : IPostRespository
    {
        readonly ImageSocialDbContext dbContext;
        public PostRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<PostEntity> AddPostAsync(PostEntity post)
        {
            var _post = dbContext.Posts.Add(post);
            await dbContext.SaveChangesAsync();

            return _post.Entity;
        }

        public List<PostEntity> GetPosts()
        {
            return dbContext.Posts.ToList();
        }

        public async Task<List<PostEntity>> GetPostsAsync()
        {
            return await dbContext.Posts.ToListAsync();
        }
    }
}
