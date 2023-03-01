using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure;

namespace ImageSocialNetwork.Infrastructure.Configurations
{
    public class ImageConfiguration
    {
        readonly ImageSocialNetwork.Infrastructure.EF.ImageSocialDbContext dbContext;

        public ImageConfiguration(ImageSocialNetwork.Infrastructure.EF.ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Entities.ImageEntity> GetImages()
        {
            return dbContext.Images.ToList();
        }
    }
}
