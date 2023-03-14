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
    class GetAccountsHandler : IRequestHandler<GetAccountsQuery, List<AccountEntity>>
    {
        readonly AccountRepository accountRepo;

        public GetAccountsHandler(AccountRepository repository)
        {
            accountRepo = repository;
        }

        public async Task<List<AccountEntity>> Handle(GetAccountsQuery query, CancellationToken cancellationToken)
        {
            return await accountRepo.GetAccountsAsync();
        }

    }
}
