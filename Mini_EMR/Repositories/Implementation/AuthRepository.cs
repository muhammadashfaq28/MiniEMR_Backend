using Mini_EMR.Data;
using Mini_EMR.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Mini_EMR.Entities;

namespace Mini_EMR.Repositories.Implementation
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        public AuthRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<User?> GetUsernameAsync(string username)
        {
            return await _context.Users
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
