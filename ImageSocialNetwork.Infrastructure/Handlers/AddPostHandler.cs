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
    class AddPostHandler : IRequestHandler<AddPostCommand, int>
    {
        IPostRespository respository;

        public AddPostHandler(IPostRespository repo)
        {
            respository = repo;
        }

        public async Task<int> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            PostEntity post = new PostEntity
            {
                Caption = request.Caption,
                User = new UserEntity
                {
                    UserID = request.UserID
                }
            };

            return await respository.AddPostAsync(post);
        }
    }
}
