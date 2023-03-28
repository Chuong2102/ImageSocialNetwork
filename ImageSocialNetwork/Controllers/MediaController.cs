using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Repositories;
using ImageSocialNetwork.Infrastructure.EF;
using MediatR;
using ImageSocialNetwork.Infrastructure.Commands;
using ImageSocialNetwork.Infrastructure.Entities;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ImageSocialNetwork.Controllers
{
    [ApiController]
    public class MediaController : ControllerBase
    {
        IMediator mediator;
        IWebHostEnvironment environment;

        public MediaController(IMediator mediator, IWebHostEnvironment env)
        {
            this.mediator = mediator;
            this.environment = env;
        }

        #region UPLOAD METHOD
        async Task<string> UploadImage(IFormFile file)
        {
            if (file.Length > 0)
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
                catch (Exception ex)
                {
                    return ex.ToString();
                }

            }

            return "Not success";
        }

        #endregion

        [HttpPost]
        [Route("api/AddPost")]
        public async Task<PostEntity> AddPost([FromBody] AddPostCommand post,[FromForm] IFormFile file)
        {
            // Up new Images and get path of them
            string ImagePath = await UploadImage(file);

            // Create new POST
            var newPost = await mediator.Send(post);

            // Create new Images
            ImageEntity image = new ImageEntity
            {
                Name = file.FileName,
                ImagePath = ImagePath,
                Post = newPost
            };

            var newImage = await mediator.Send(new AddImageCommand(image));

            return newPost;
        }


    }
}
