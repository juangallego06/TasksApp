using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tasks.Application.Interfaces.Persistence;
using Tasks.Infrastructure.Persistence.Contexts;
using Tasks.Infrastructure.Persistence.Repositories;

namespace Tasks.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TaskDbConnection")));

            // Register repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
