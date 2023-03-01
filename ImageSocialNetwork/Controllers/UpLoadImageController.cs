using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Configurations;
using ImageSocialNetwork.Infrastructure.EF;

namespace ImageSocialNetwork.Controllers
{
    [Route("api/UpLoadImage")]
    [ApiController]
    public class UpLoadImageController : ControllerBase
    {
        ImageConfiguration imageConfiguration;

        public UpLoadImageController(ImageSocialDbContext context)
        {
            imageConfiguration = new ImageConfiguration(context);
        }

        [HttpGet]
        public IEnumerable<ImageSocialNetwork.Infrastructure.Entities.ImageEntity> GetImages()
        {
            return imageConfiguration.GetImages().ToArray();
        }
    }
}
