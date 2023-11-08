using KlumperBank.Models;
using KlumperBank.ViewModel;

namespace KlumperBank.Repositories.Contracts
{
    public interface IUpdateUserRepository
    {
        Task<User> UpdateUser(int id, UpdateViewModel model);
    }
}
