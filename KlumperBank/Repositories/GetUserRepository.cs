using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using KlumperBank.ViewModel;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace KlumperBank.Repositories
{
    public class GetUserRepository : IGetUserRepository
    {

        private readonly KlumperBankDtContext _context;
        public GetUserRepository(KlumperBankDtContext context)
        {
            _context = context;
        }

        public User GetUserForLogin(string email, string password, LoginViewModel model)
        {
            var user = _context.Users
                .FirstOrDefault(x =>
                    x.Email.ToLower() == email.ToLower());

            if (user == null)
                throw new Exception("#01 Usuario ou senha invalidos");        

            if (!PasswordHasher.Verify(user.Password, model.Password))
                 throw new Exception("#02 Usuario ou senha invalidos");

            return user;
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
