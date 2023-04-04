using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public interface IPostRespository
    {
        public Task<List<PostEntity>> GetPostsAsync();
        public List<PostEntity> GetPosts();
        public Task<int> AddPostAsync(PostEntity post);
        public Task<IEnumerable<PostEntity>> GetFollwingUserPosts(int UserID);
        public Task<IEnumerable<PostEntity>> GetPost(int UserID);

    }
}
