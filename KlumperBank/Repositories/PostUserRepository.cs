using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using KlumperBank.Services;
using SecureIdentity.Password;

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
            var user = new User { Name = model.Name, Email = model.Email, Balance = model.Balance, Role = model.Role};
            var password = PasswordGenerator.Generate(4);

            EmailService.Send(user.Name, user.Email, "Bem vindo ao blog!", $"Sua senha é {password}");

            user.Password = PasswordHasher.Hash(password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
