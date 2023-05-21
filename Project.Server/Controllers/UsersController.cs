using Microsoft.AspNetCore.Mvc;
using Project.Server.Models.Users;
using Project.Server.Services;

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
        public async Task<IEnumerable<User>> Get(SearchUser searchUser, int pageNumber, int pageSize)
        {
            return await userService.GetUsers(searchUser, pageNumber, pageSize);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<User>> Search(SearchUser searchUser)
        {
            return await userService.SearchUsers(searchUser);
        }
    }
}
