namespace Tasks.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ITaskItemRepository TaskItems { get; }
    }
}
