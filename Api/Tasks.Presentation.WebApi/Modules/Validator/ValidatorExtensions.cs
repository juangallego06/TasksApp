using Tasks.Application.Validators;

namespace Tasks.Presentation.WebApi.Modules.Validator
{
    public static class ValidatorExtensions
    {
        public static IServiceCollection AddValidator(this IServiceCollection services)
        {
            services.AddTransient<CreateTaskItemDtoValidator>();
            services.AddTransient<CreateUserDtoValidator>();
            return services;
        }
    }
}
