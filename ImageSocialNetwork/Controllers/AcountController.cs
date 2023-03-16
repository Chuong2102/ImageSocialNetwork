using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageSocialNetwork.Infrastructure.Entities;
using ImageSocialNetwork.Infrastructure.Configurations;
using static ImageSocialNetwork.Infrastructure.Configurations.AccountConfiguration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using ImageSocialNetwork.Infrastructure.Repositories;
using ImageSocialNetwork.Infrastructure.EF;
using MediatR;
using ImageSocialNetwork.Infrastructure.Queries;

namespace ImageSocialNetwork.Controllers
{
    
    [ApiController]
    public class AcountController : ControllerBase
    {
        AccountRepository accountRepo;
        IMediator mediator;

        //public AcountController(IConfiguration config, ImageSocialDbContext context)
        //{
        //    accountRepo = new AccountRepository(context, config);
        //}

        public AcountController(IMediator media)
        {
            mediator = media;
        }


        [HttpGet]
        [Route("api/SignUp")]
        public Task SignUp(int ID, string Username, string Password, string Role)
        {
            accountRepo.AddAccount(ID, Username, Password, Role);
            return Task.CompletedTask;
        }

        [Authorize]
        [Route("api/GetAccounts")]
        [HttpGet]
        public async Task<List<AccountEntity>> GetAccounts()
        {
            var accounts = await mediator.Send(new GetAccountsQuery());

            return accounts;
        }

        [HttpPost]
        [Route("api/Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetTokenAsync(string username, string password)
        {
            var account = await mediator.Send(new GetAccountQuery
            {
                Username = username,
                Password = password
            });

            if(account == null)
            {
                return NotFound(new { message = "User or password invalid" });
            }

            // JWT
            var jwtSecurityToken = AccountService.CreateJWTToken(account);

            account.Password = "";
            return new
            {
                account = account,
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

        }

        [HttpGet]
        [Route("api/GetSecuredData")]
        public async Task<IActionResult> GetSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Users");
        }

        [HttpPost]
        [Authorize]
        [Route("api/PostSecuredData")]
        public async Task<IActionResult> PostSecuredData()
        {
            return Ok("This Secured Data is available only for Authenticated Users");
        }
    }
}
