using Tasks.Shared.Common;
using Tasks.Shared.Logging;

namespace Tasks.Presentation.WebApi.Modules.Injection
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            //services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}
