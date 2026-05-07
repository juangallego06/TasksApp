using AutoMapper;
using Tasks.Shared.Mapper;

namespace Tasks.Presentation.WebApi.Modules.Mapper;

public static class MapperExtensions
{
    public static IServiceCollection AddMapper(
        this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MappingsProfile>();
        });

        return services;
    }
}