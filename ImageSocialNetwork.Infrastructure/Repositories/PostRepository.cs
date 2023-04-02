using ImageSocialNetwork.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;

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

            // Output para
            var output = new SqlParameter();
            output.ParameterName = "@PostID";
            output.SqlDbType = SqlDbType.Int;
            output.Direction = ParameterDirection.Output;
            //
            var par0 = new SqlParameter("@Caption", post.Caption);
            var par1 = new SqlParameter("@UserID", post.User.UserID);

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddPost @UserID, @Caption, @PostID OUT", par0, par1, output));

            return (int)output.Value;
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
