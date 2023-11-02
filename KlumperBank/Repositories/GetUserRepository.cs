using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace KlumperBank.Repositories
{
    public class GetUserRepository : IGetUserRepository
    {

        private readonly KlumperBankDtContext _context;
        public GetUserRepository(KlumperBankDtContext context)
        {
            _context = context;
        }

        public Task<User> GetUserById(int userId)
        {
                return _context.Users.AsNoTracking().Where(x => x.Id == userId).FirstOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.AsNoTracking().ToListAsync();
        }
    }
}
