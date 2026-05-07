using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces.Persistence;
using Tasks.Domain.Entity;
using Tasks.Infrastructure.Persistence.Contexts;

namespace Tasks.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext _context;

        public UserRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking()
                .OrderBy(x => x.UserName)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
