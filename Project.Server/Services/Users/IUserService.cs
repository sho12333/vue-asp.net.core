
using Project.Domain.Entities.Users;

namespace Project.Server.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(int id);

        Task<IEnumerable<User>> SearchUsers(SearchUser searchUser);
    }
}
