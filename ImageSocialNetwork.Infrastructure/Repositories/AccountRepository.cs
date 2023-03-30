using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.EF;
using ImageSocialNetwork.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;

namespace ImageSocialNetwork.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ImageSocialDbContext dbContext;
        public static IConfiguration config;

        public AccountRepository(ImageSocialDbContext dbContext, IConfiguration _config)
        {
            this.dbContext = dbContext;
            config = _config;
        }

        // Get account by username and password
        //
        public AccountEntity GetAccount(string username, string password)
        {
            return dbContext.Accounts.Where(account => account.Username == username
            && account.Password == password).FirstOrDefault();
        }

        public async Task<AccountEntity> GetAccountAsync(string username, string password)
        {
            return await dbContext.Accounts.Where(account => account.Username == username
            && account.Password == password).FirstOrDefaultAsync();
        }

        // Get list Account
        //
        public List<AccountEntity> GetAccounts()
        {
            return dbContext.Accounts.ToList();
        }

        public async Task<List<AccountEntity>> GetAccountsAsync()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        //
        //
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
        public static AccountEntity Get(AccountRepository accountRepository, string username, string password)
        {
            return accountRepository.GetAccounts().Where(account => account.Username == username
            && account.Password == password).FirstOrDefault();

        }

        public static JwtSecurityToken CreateJWTToken(AccountEntity account)
        {
            JWT jwt = new JWT
            {
                Key = AccountRepository.config["JWT:Key"],
                Audience = AccountRepository.config["JWT:Audience"],
                Issuer = AccountRepository.config["JWT:Issuer"],
                DurationInMinutes = Double.Parse(AccountRepository.config["JWT:DurationInMinutes"])
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

        //public static ClaimsPrincipal GetPrincipal(string token)
        //{

        //}

        //public 
    }
}
