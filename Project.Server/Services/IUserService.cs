using Project.Server.Models.Users;

namespace Project.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(int id);

        Task<IEnumerable<User>> SearchUsers(SearchUser searchUser);
    }
}
