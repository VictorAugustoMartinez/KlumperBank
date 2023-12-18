using KlumperBank.Models;
using KlumperBank.ViewModel;

namespace KlumperBank.Repositories.Contracts
{
    public interface IUserRepository
    {
        User GetUserForLogin(string name, string password, LoginViewModel model);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUsers();
        Task<User> CreateUserAsync(User model);
        Task<User> TransactionUser(int senderId, int receiverId, int amount);
        Task<User> UpdateUser(int id, UpdateViewModel model);
    }
}
