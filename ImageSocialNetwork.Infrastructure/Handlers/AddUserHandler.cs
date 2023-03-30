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
    class AddUserHandler : IRequestHandler<AddUserCommand ,int>
    {
        IUserRepository repository;

        public AddUserHandler(IUserRepository repo)
        {
            this.repository = repo;
        }

        public async Task<int> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            UserEntity user = new UserEntity
            {
                UserName = request.Username,
                FullName = request.Fullname,
                Email = request.Email,
                Phone = request.Phone,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                Account = new AccountEntity
                {
                    Password = request.Password
                }
            };

            return await repository.AddUserAsync(user);
        }
    }
}
