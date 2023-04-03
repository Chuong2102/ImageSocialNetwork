using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public interface ICommentRepository
    {
        public Task<int> AddCommentAsync(int UserID, int PostID, string text);
    }
}
