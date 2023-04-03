using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public interface ILikeRepository
    {
        public Task<int> AddLikesAsync(int PostID, int UserID);
    }
}
