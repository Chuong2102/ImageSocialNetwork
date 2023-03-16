using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public interface IAccountRepository
    {
        public Task<List<AccountEntity>> GetAccountsAsync();
        public List<AccountEntity> GetAccounts();
        public AccountEntity GetAccount(string username, string password);
        public Task<AccountEntity> GetAccountAsync(string username, string password);
    }
}
