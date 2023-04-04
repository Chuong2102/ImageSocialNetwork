using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;
using ImageSocialNetwork.Infrastructure.Queries;
using ImageSocialNetwork.Infrastructure.Repositories;
using System.Threading;

namespace ImageSocialNetwork.Infrastructure.Handlers
{
    public class GetFollwingUserPostHandler : IRequestHandler<GetFollowingUserPostQuery, IEnumerable<PostEntity>>
    {
        readonly IPostRespository repo;
        public GetFollwingUserPostHandler(IPostRespository repo)
        {
            this.repo = repo;
        }
        public async Task<IEnumerable<PostEntity>> Handle(GetFollowingUserPostQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetFollwingUserPosts(request.UserID);
        }
    }
}
