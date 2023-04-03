using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Commands
{
    public class AddCommentCommand : IRequest<int>
    {
        public int UserID { get; set; }
        public int PostID { get; set; }
        public string Text { get; set; }

        public AddCommentCommand(int UserID, int PostID, string Text)
        {
            this.UserID = UserID;
            this.PostID = PostID;
            this.Text = Text;
        }
    }
}
