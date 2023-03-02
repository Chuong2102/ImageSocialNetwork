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

namespace ImageSocialNetwork.Controllers
{
    [Route("api/Login")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        AccountConfiguration accountConfig;

        public AcountController(ImageSocialNetwork.Infrastructure.EF.ImageSocialDbContext context)
        {
            accountConfig = new AccountConfiguration(context);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> GetTokenAsync(string userName, string password)
        {
            var account = AccountService.Get(accountConfig, userName, password);

            if(account == null)
            {
                return NotFound(new { message = "User or password invalid" });
            }

            var jwtSecurityToken = AccountService.CreateJWTToken(account);

            account.Password = "";
            return new
            {
                account = account,
                token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };

        }
    }
}
