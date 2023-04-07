using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Configurations;
using ImageSocialNetwork.Infrastructure.EF;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ImageSocialNetwork.Controllers
{
    [ApiController]
    public class UpLoadImageController : ControllerBase
    {
        IWebHostEnvironment environment;
        public UpLoadImageController(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        [HttpPost]
        [Route("api/Upload")]
        public async Task<string> Upload([FromForm]IFormFile file)
        {
            if(file.Length > 0)
            {
                try
                {
                    DirectoryInfo directoryInfo;

                    if (!Directory.Exists(environment.WebRootPath + "\\Images\\"))
                    {
                        directoryInfo = Directory.CreateDirectory(environment.WebRootPath + "\\Images\\");
                    }

                    FileStream fileStream = System.IO.File.Create(environment.WebRootPath + "\\Images\\" + file.FileName);
                    await file.CopyToAsync(fileStream);
                    fileStream.Flush();

                    return environment.WebRootPath + "\\Images\\" + file.FileName;

                    
                }
                catch(Exception ex)
                {
                    return ex.ToString();
                }

            }

            return "Not success";

        }
    }
}
