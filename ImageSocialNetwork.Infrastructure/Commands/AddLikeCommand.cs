using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddLikeCommand : IRequest<int>
    {
        public int UserID { get; set; }
        public int PostID { get; set; }

        public AddLikeCommand(int UserID, int PostID)
        {
            this.UserID = UserID;
            this.PostID = PostID;
        }
    }
}
