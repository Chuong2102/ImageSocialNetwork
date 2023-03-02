using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ImageSocialNetwork.Infrastructure.Configurations
{
    public class AccountConfiguration
    {
        ImageSocialDbContext dbContext;

        public AccountConfiguration(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<AccountEntity> GetAccounts()
        {
            return dbContext.Accounts.ToList();
        }

        public static class AccountService
        {
            public static AccountEntity Get(AccountConfiguration accountConfig, string username, string password)
            {
                return accountConfig.GetAccounts().Where(account => account.Username == username 
                && account.Password == password).FirstOrDefault();

            }

            public static JwtSecurityToken CreateJWTToken(AccountEntity account)
            {
                JWT jwt = new JWT();

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim(ClaimTypes.Role, account.Role)
                };

                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var jwtSecurityToken = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(jwt.DurationInMinutes),
                signingCredentials: signingCredentials);
                return jwtSecurityToken;
            }
        }
    }
}

