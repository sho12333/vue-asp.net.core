using Project.Server.Models.Users;

namespace Project.Server.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers(SearchUser seachUser, int pageNumber, int pageSize);

        Task<IEnumerable<User>> SearchUsers(SearchUser searchUser);
    }
}
