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

        public User GetUserForLogin(string name, string password)
        {
            return _context.Users
                .FirstOrDefault(x =>
                    x.Name.ToLower() == name.ToLower() && x.Password.ToLower() == password.ToLower());              
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
