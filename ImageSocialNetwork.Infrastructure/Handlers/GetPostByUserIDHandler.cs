using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;
using ImageSocialNetwork.Infrastructure.Queries;
using ImageSocialNetwork.Infrastructure.Repositories;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Handlers
{
    class GetPostByUserIDHandler : IRequestHandler<GetPostByUserIDQuery, IEnumerable<PostEntity>>
    {
        readonly IPostRespository repo;
        public GetPostByUserIDHandler(IPostRespository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<PostEntity>> Handle(GetPostByUserIDQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetFollwingUserPosts(request.UserID);
        }
    }
}
