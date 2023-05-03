using FluentValidation;

using GigaChat.Core.Common.Behaviors;
using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Common.Services.Realisations;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace GigaChat.Core;

public static class Module
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        var assembly = typeof(Module).Assembly;

        services.AddMediatR(options =>
        {
            options.RegisterServicesFromAssembly(assembly);
            options.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(assembly);

        services.AddScoped<IDateTimeProvider, DateTimeTimeProvider>();
        services.AddScoped<IPasswordHashProvider, PasswordHashProvider>();

        return services;
    }
}