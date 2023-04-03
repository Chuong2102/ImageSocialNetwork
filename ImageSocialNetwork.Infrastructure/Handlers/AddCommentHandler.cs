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
    class AddCommentHandler : IRequestHandler<AddCommentCommand, int>
    {
        readonly ICommentRepository repo;
        public AddCommentHandler(ICommentRepository repo)
        {
            this.repo = repo;
        }
        public async Task<int> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            return await repo.AddCommentAsync(request.UserID, request.PostID, request.Text);
        }
    }
}
