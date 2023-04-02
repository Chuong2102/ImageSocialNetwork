using ImageSocialNetwork.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class PostRepository : IPostRespository
    {
        readonly ImageSocialDbContext dbContext;
        public PostRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddPostAsync(PostEntity post)
        {
            var parameters = new List<SqlParameter>();
            int postID = -5;

            parameters.Add(new SqlParameter("@Caption", post.Caption));
            parameters.Add(new SqlParameter("@UserID", post.User.UserID));
            parameters.Add(new SqlParameter("@PostID", postID));

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddPost @UserID, @Caption, @PostID out", parameters.ToArray()
            ));

            return (int)parameters.ToArray()[2].Value;
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
