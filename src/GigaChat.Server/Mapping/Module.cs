using Mapster;

using MapsterMapper;

namespace GigaChat.Server.Mapping;

public static class Module
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(typeof(Module).Assembly);
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        return services;
    }
}