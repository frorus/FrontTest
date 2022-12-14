using FrontTest.Data;
using FrontTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FrontTestContext _context;

        public UserRepository(FrontTestContext context)
        {
            _context = context;
        }

        public async Task Create(AppUser user)
        {
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<AppUser> GetUserById(Guid id)
        {
            return await _context.ApplicationUsers.FindAsync(id);
        }

        public async Task<AppUser> GetUserByPhone(string phone)
        {
            return await _context.ApplicationUsers.FirstOrDefaultAsync(l => l.Phone == phone);
        }

        public Task<bool> UserExists(string phone)
        {
            return Task.FromResult((_context.ApplicationUsers?.Any(e => e.Phone == phone)).GetValueOrDefault());
        }
    }
}
