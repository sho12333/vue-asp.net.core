using Project.Server.Models.Users;

namespace Project.Server.Repositories.Users
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync(int id);

        Task<IEnumerable<User>> SearchAsync(SearchUser searchUser);

        Task InsertAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(int id);
    }
}
