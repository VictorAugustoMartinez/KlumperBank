using KlumperBank.Data;
using KlumperBank.Models;
using KlumperBank.Repositories.Contracts;
using KlumperBank.Services;
using KlumperBank.ViewModel;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace KlumperBank.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly KlumperBankDtContext _context;
        public UserRepository(KlumperBankDtContext context)
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
        public async Task<User> CreateUserAsync(User model)
        {
            var user = new User { Name = model.Name, Email = model.Email, Balance = model.Balance, Role = model.Role };
            var password = PasswordGenerator.Generate(4);

            await EmailService.Send(user.Name, user.Email, "Bem vindo ao blog!", $"Sua senha é {password}");

            user.Password = PasswordHasher.Hash(password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            user.Password = "*****";
            return user;
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
            senderUser.Password = "*****";
            return senderUser;
        }
        public async Task<User> UpdateUser(int id, UpdateViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new Exception("O usuario nao existe");

            user.Name = model.Name;
            user.Password = model.Password;

            user.Password = PasswordHasher.Hash(user.Password);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            user.Password = "*****";
            return user;
        }
    }
}
