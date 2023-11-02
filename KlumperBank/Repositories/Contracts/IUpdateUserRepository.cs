using KlumperBank.Models;

namespace KlumperBank.Repositories.Contracts
{
    public interface IUpdateUserRepository
    {
        Task<User> UpdateUser(int id, User model);
    }
}
