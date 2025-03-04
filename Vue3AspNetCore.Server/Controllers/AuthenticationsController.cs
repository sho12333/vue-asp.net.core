using Microsoft.AspNetCore.Mvc;
using Vue3AspNetCore.Domain.Authentications.Entities;

namespace Vue3AspNetCore.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationsController : ControllerBase
    {
        /// <summary>
        /// Config
        /// </summary>
        private readonly IConfiguration _configuration;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="configuration"></param>
        public AuthenticationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            return Unauthorized();
        }
    }
}