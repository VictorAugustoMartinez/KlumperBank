using KlumperBank.Models;
using KlumperBank.ViewModel;

namespace KlumperBank.Repositories.Contracts
{
    public interface IGetUserRepository
    {
        User GetUserForLogin(string name, string password, LoginViewModel model);
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUsers();
    }
}
