using KlumperBank.Models;
using KlumperBank.ViewModel;

namespace KlumperBank.Repositories.Contracts
{
    public interface ITransactionUserRepository 
    {
        Task<User> TransactionUser(int senderId, int receiverId, int amount);
    }
}
