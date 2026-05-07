using Microsoft.Extensions.DependencyInjection;
using Tasks.Application.Interfaces.UseCases;

namespace Tasks.Application.UseCases
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddScoped<IUserUseCase, UserUseCase>();
            services.AddScoped<ITaskItemUseCase, TaskItemUseCase>();

            return services;
        }
    }
}
