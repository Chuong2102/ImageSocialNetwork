using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddPostCommand : IRequest<int>
    {
        public string Caption { get; set; }
        public int UserID { get; set; }

        public AddPostCommand(string Caption, int UserID)
        {
            this.Caption = Caption;
            this.UserID = UserID;
        }
    }
}
