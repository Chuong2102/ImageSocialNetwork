using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        public Task<int> AddUserAsync(UserEntity user);
    }
}
