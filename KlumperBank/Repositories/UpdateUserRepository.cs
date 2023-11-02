using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KlumperBank.Repositories
{
    public class UpdateUserRepository : IUpdateUserRepository
    {
        private readonly KlumperBankDtContext _context;
        public UpdateUserRepository(KlumperBankDtContext context)
        {
            _context = context;
        }

        public async Task<User> UpdateUser(int id, User model)
        {
            var user =  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new Exception("O usuario nao existe");

            user.Name = model.Name;
            user.Balance = model.Balance;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
