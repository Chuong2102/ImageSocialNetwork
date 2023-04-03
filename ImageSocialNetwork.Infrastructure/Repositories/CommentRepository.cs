using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        readonly ImageSocialDbContext dbContext;
        public CommentRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddCommentAsync(int UserID, int PostID, string text)
        {
            // Output para
            var output = new SqlParameter();
            output.ParameterName = "@Result";
            output.SqlDbType = SqlDbType.Int;
            output.Direction = ParameterDirection.Output;
            // List para
            var par0 = new SqlParameter("@UserID", UserID);
            var par1 = new SqlParameter("@PostID", PostID);
            var par2 = new SqlParameter("@Text", text);

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddComment @UserID, @PostID, @Text, @Result OUT", par0, par1, par2, output));

            return (int)output.Value;
        }
    }
}
