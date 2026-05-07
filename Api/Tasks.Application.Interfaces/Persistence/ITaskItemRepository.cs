using Tasks.Domain.Entity;
using Tasks.Domain.Entity.Enums;

namespace Tasks.Application.Interfaces.Persistence
{
    public interface ITaskItemRepository
    {
        Task<IEnumerable<TaskItem>> GetAllAsync(TaskItemStatus? status = null);

        Task<TaskItem?> GetByIdAsync(int id);

        Task<TaskItem> AddAsync(TaskItem taskItem);

        Task<TaskItem> UpdateAsync(TaskItem taskItem);
    }
}
