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
    class AddImageHandler : IRequestHandler<AddImageCommand, int>
    {
        IIamgeRepository repository;
        public AddImageHandler(IIamgeRepository repo)
        {
            repository = repo;
        }

        public async Task<int> Handle(AddImageCommand request, CancellationToken cancellationToken)
        {
            ImageEntity image = new ImageEntity
            {
                Post = new PostEntity
                {
                    PostID = request.PostID
                },
                Name = request.Name,
                ImagePath = request.ImagePath
            };

            return await repository.AddImageAsync(image);
        }
    }
}
