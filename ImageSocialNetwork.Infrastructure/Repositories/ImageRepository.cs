using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class ImageRepository : IIamgeRepository
    {
        ImageSocialDbContext dbContext;

        public ImageRepository(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ImageEntity> AddImageAsync(ImageEntity image)
        {
            var _image = dbContext.Images.Add(image);
            await dbContext.SaveChangesAsync();

            return _image.Entity;
        }
    }
}
