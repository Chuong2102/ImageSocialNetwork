using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ImageSocialNetwork.Infrastructure.Entities;
using ImageSocialNetwork.Infrastructure.Commands;
using ImageSocialNetwork.Infrastructure.Repositories;
using System.Threading;

namespace ImageSocialNetwork.Infrastructure.Handlers
{
    public class AddLikeHandler : IRequestHandler<AddLikeCommand, int>
    {
        readonly ILikeRepository repo;

        public AddLikeHandler(ILikeRepository repo)
        {
            this.repo = repo;
        }

        public async Task<int> Handle(AddLikeCommand request, CancellationToken cancellationToken)
        {
            return await repo.AddLikesAsync(request.PostID, request.UserID);
        }
    }
}
