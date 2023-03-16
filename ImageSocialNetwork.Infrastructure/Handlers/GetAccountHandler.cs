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
    class GetAccountHandler : IRequestHandler<GetAccountQuery, AccountEntity>
    {
        IAccountRepository repo;
        public GetAccountHandler(IAccountRepository repository)
        {
            repo = repository;
        }

        public async Task<AccountEntity> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            return await repo.GetAccountAsync(request.Username, request.Password);
        }
    }
}
