using GigaChat.Core.Common.Repositories.Common.Interfaces;
using GigaChat.Core.Common.Repositories.Interfaces;
using GigaChat.Data.Repositories;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GigaChat.Data;

public static class Module
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<GigaChatDbContext>(options => GigaChatDbContext.Configure(options, configuration));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
        services.AddScoped<IChatRoomRepository, ChatRoomRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}