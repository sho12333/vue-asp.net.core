using Microsoft.AspNetCore.Mvc;
using Project.Domain.Entities.Users;
using Project.Server.Services;
using Project.Server.Services.Users;

namespace Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IEnumerable<User>> Get(int id)
        {
            return await userService.GetUsers(id);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<User>> Search([FromBody]SearchUser searchUser)
        {
            return await userService.SearchUsers(searchUser);
        }
    }
}
