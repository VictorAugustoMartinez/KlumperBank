using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;

namespace KlumperBank.Repositories
{
    public class PostUserRepository : IPostUserRepository
    {
        private readonly KlumperBankDtContext _context;
        public PostUserRepository(KlumperBankDtContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User model)
        {
            var user = new User { Name = model.Name, Password = model.Password ,Balance = model.Balance, Role = model.Role};

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
