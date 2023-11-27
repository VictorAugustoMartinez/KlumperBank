using KlumperBank.Models;

namespace KlumperBank.Repositories.Contracts
{
    public interface ITransactionUserRepository 
    {
        Task<User> TransactionUser(int senderId, int receiverId, int amount);
    }
}
