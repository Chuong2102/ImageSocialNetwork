using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddImageCommand : IRequest<ImageEntity>
    {
        public int PostID { get; set; }
        public string ImagePath { get; set; }
        public string Name { get; set; }

        public AddImageCommand(ImageEntity image)
        {
            this.PostID = image.Post.PostID;
            this.ImagePath = image.ImagePath;
            this.Name = image.Name;
        }
    }
}
