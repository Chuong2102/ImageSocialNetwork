using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ImageSocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("Admin")]
        [Authorize]
        public IActionResult Admin()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            string Role = "";

            if(identity != null)
            {
                var userclaims = identity.Claims;
                Role = userclaims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            }

            return Ok(Role);
        }
    }
}
