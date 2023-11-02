using KlumperBank.Models;

namespace KlumperBank.Repositories.Contracts
{
    public interface IGetUserRepository
    {
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUsers();
    }
}
