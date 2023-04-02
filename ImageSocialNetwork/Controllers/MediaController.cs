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

        public class FileUploadAPI
        {
            public string Caption { get; set; }
            public int UserID { get; set; }
            public IFormFile file { get; set; }
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

        // Create new post and upload new images to this post
        //
        [HttpPost]
        [Route("api/AddPost")]
        public async Task<int> AddPost([FromForm]FileUploadAPI fileUpload)
        {
            // Up new Images and get path of them
            string ImagePath = await UploadImage(fileUpload.file);

            // Create new POST
            var PostID = await mediator.Send(new AddPostCommand(fileUpload.Caption, fileUpload.UserID));

            // Create new Images
            ImageEntity image = new ImageEntity
            {
                Name = fileUpload.file.FileName,
                ImagePath = ImagePath,
                Post = new PostEntity
                {
                    PostID = PostID
                }
            };

            var newImage = await mediator.Send(new AddImageCommand(image));

            return PostID;
        }

        // Create new User
        [HttpPost]
        [Route("api/AddUser")]
        public async Task<int> AddUser([FromBody] UserEntity user)
        {

            var result = await mediator.Send(new AddUserCommand(user));

            return result;
        }
        
            

    }
}
