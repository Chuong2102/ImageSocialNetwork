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
    public class LikeRepository : ILikeRepository
    {
        readonly ImageSocialDbContext dbContext;
        public LikeRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddLikesAsync(int PostID, int UserID)
        {
            // Output para
            var output = new SqlParameter();
            output.ParameterName = "@Result";
            output.SqlDbType = SqlDbType.Int;
            output.Direction = ParameterDirection.Output;
            // List para
            var par0 = new SqlParameter("@PostID", PostID);
            var par1 = new SqlParameter("@UserID", UserID);

            var result = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddLike @PostID, @UserID, @Result OUT", par0, par1, output));

            return (int)output.Value;
        }
    }
}
