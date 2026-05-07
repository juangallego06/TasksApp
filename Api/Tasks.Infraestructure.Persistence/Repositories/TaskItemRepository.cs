using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces.Persistence;
using Tasks.Domain.Entity;
using Tasks.Domain.Entity.Enums;
using Tasks.Infrastructure.Persistence.Contexts;

namespace Tasks.Infrastructure.Persistence.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly TaskDbContext _context;

        public TaskItemRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> AddAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
            return taskItem;
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync(TaskItemStatus? status = null)
        {
            IQueryable<TaskItem> query = _context.TaskItems
                .AsNoTracking()
                .Include(x => x.User);

            if(status.HasValue)
            {
                query = query.Where(x => x.Status == status.Value);
            }

            return await query
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.TaskItems
                .AsNoTracking()
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);

            await _context.SaveChangesAsync();

            return taskItem;
        }
    }
}
