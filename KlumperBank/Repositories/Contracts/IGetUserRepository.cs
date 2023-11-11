using KlumperBank.Models;

namespace KlumperBank.Repositories.Contracts
{
    public interface IGetUserRepository
    {
        User GetUserForLogin(string name, string password);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUsers();
    }
}
