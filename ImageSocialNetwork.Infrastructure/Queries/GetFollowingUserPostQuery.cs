using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Queries
{
    public class GetFollowingUserPostQuery :IRequest<IEnumerable<PostEntity>>
    {
        public int UserID { get; set; }
    }
}
