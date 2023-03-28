using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddPostCommand : IRequest<PostEntity>
    {
        public string Caption { get; set; }
        public int UserID { get; set; }

        public AddPostCommand(PostEntity post)
        {
            this.Caption = post.Caption;
            this.UserID = post.User.UserID;
        }
    }
}
