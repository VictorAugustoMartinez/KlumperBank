using KlumperBank.Models;

namespace KlumperBank.Repositories.Contracts
{
    public interface IPostUserRepository
    {
        Task<User> CreateUserAsync(User model);
    }
}
