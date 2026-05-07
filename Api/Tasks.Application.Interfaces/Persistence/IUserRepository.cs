using Tasks.Domain.Entity;

namespace Tasks.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User?> GetByIdAsync(int id);

        Task<User> AddAsync(User user);
    }
}
