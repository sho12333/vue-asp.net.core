
using Project.Domain.Entities.Users;
using Project.Infrastructure.Data.Repositories.Users;

namespace Project.Server.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetUsers(int id)
        {
            return await userRepository.GetUsersAsync(id);
        }

        public async Task<IEnumerable<User>> SearchUsers(SearchUser searchUser)
        {
            return await userRepository.SearchAsync(searchUser);
        }
    }
}
