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
using Dapper;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class PostRepository : IPostRespository
    {
        readonly ImageSocialDbContext dbContext;
        readonly Dapper.DapperContext dapperContext;
        public PostRepository(ImageSocialDbContext dbContext, Dapper.DapperContext dapper)
        {
            this.dbContext = dbContext;
            this.dapperContext = dapper;
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

        public async Task<IEnumerable<PostEntity>> GetFollwingUserPosts(int UserID)
        {
            //var par = new SqlParameter("@UserID", UserID);
            //List<PostEntity> listPost = new List<PostEntity>();

            //try
            //{
            //    listPost = await Task.Run(() => dbContext.Posts.FromSqlRaw(
            //    @"exec proc_FollowingPost @UserID", par).ToListAsync());


            //}
            //catch(Exception ex)
            //{

            //}

            //return listPost;

            var para = new DynamicParameters();

            para.Add("UserID", UserID, DbType.Int32);

            using(var connection = dapperContext.CreateConnection())
            {
                var result = await connection.QueryAsync<PostEntity>("proc_FollowingPost", para, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<PostEntity>> GetPost(int UserID)
        {
            List<PostEntity> posts = new List<PostEntity>();

            try
            {
                posts = await dbContext.Posts.Where(p => p.User.UserID == UserID).ToListAsync();
            }
            catch(Exception ex)
            {

            }

            return posts;
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
