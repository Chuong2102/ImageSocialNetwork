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
    public class AddUserHandler : IRequestHandler<AddUserCommand ,int>
    {
        IUserRepository repository;

        public AddUserHandler(IUserRepository repo)
        {
            this.repository = repo;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await repository.AddUserAsync(request.Username, request.Password, request.Fullname,
                request.Phone, request.Gender, request.Email, request.DateOfBirth);
        }
    }
}
