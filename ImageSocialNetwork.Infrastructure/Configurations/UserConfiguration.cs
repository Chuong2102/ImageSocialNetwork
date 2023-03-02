using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;

namespace ImageSocialNetwork.Infrastructure.Configurations
{
    public class UserConfiguration
    {
        ImageSocialDbContext dbContext;
        public UserConfiguration(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // Get user
        public List<UserEntity> GetUsers()
        {
            return dbContext.Users.ToList();
        }

    }

    public static class UserService
    {
        public static UserEntity Get(UserConfiguration userConfig)
        {
            return userConfig.GetUsers().FirstOrDefault();

        }
    }
}
