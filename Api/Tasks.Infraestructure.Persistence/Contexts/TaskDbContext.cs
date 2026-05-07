using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Entity;

namespace Tasks.Infrastructure.Persistence.Contexts
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();

        public DbSet<TaskItem> TaskItems => Set<TaskItem>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskDbContext).Assembly);
        }
    }
}
