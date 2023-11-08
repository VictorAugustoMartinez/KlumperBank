using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using KlumperBank.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace KlumperBank.Repositories
{
    public class TransactionUserRepository : ITransactionUserRepository
    {
        private readonly KlumperBankDtContext _context;
        public TransactionUserRepository(KlumperBankDtContext context)
        {
            _context = context;
        }

       
        public async Task<User> TransactionUser(int senderId, int receiverId, int amount)
        {
            var senderUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == senderId);
            var receiverUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == receiverId);

            if (senderUser == null)
                throw new Exception("O usuario nao existe");

            if (receiverUser == null)
                throw new Exception("O usuario nao existe");

            if (senderUser.Balance < amount)
                throw new Exception("O usuario nao tem o dinheiro para realizar a transferencia");

            senderUser.Balance = senderUser.Balance - amount;
            receiverUser.Balance = receiverUser.Balance + amount;

            _context.Users.Update(senderUser);
            _context.Users.Update(receiverUser);
            await _context.SaveChangesAsync();
            return senderUser;
        }
    }
}
