using Tasks.Application.Interfaces.Persistence;

namespace Tasks.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository Users { get; }
        public ITaskItemRepository TaskItems { get; }

        public UnitOfWork(IUserRepository users, ITaskItemRepository taskItems)
        {
            Users = users;
            TaskItems = taskItems;
        }

        public void Dispose() 
        { 
            GC.SuppressFinalize(this);
        }
    }
}
