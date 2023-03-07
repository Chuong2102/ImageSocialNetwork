using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ImageSocialNetwork.Infrastructure.Configurations
{
    public class AccountConfiguration
    {
        ImageSocialDbContext dbContext;
        public IConfiguration config;

        public AccountConfiguration(ImageSocialDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public AccountConfiguration(ImageSocialDbContext dbContext, IConfiguration config)
        {
            this.dbContext = dbContext;
            this.config = config;
        }

        public List<AccountEntity> GetAccounts()
        {
            return dbContext.Accounts.ToList();
        }

        public void AddAccount(int ID, string Username, string Password, string Role)
        {
            dbContext.Accounts.Add(new AccountEntity
            {
                AcountID = ID,
                Username = Username,
                Password = Password,
                Role = Role
            });

            dbContext.SaveChanges();
        }
    }

    public static class AccountService
    {
        public static AccountEntity Get(AccountConfiguration accountConfig, string username, string password)
        {
            return accountConfig.GetAccounts().Where(account => account.Username == username
            && account.Password == password).FirstOrDefault();

        }

        public static JwtSecurityToken CreateJWTToken(AccountEntity account, AccountConfiguration configuration)
        {
            JWT jwt = new JWT
            {
                Key = configuration.config["JWT:Key"],
                Audience = configuration.config["JWT:Audience"],
                Issuer = configuration.config["JWT:Issuer"],
                DurationInMinutes = Double.Parse(configuration.config["JWT:DurationInMinutes"])
            };

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

