using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class ImageRepository : IIamgeRepository
    {
        ImageSocialDbContext dbContext;

        public ImageRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddImageAsync(ImageEntity image)
        {
            var parameters = new List<SqlParameter>();

            int result = -1;

            parameters.Add(new SqlParameter("@PostID", image.Post.PostID));
            parameters.Add(new SqlParameter("@ImagePath", image.ImagePath));
            parameters.Add(new SqlParameter("@Name", image.Name));
            parameters.Add(new SqlParameter("@Result", result));

            var Queryresult = await Task.Run(() => dbContext.Database.ExecuteSqlRawAsync(
                @"exec proc_AddImage @PostID, @ImagePath, @Name, @Result out", parameters.ToArray()
            ));

            return Queryresult;
        }
    }
}
