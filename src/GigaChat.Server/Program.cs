using GigaChat.Contracts.Common.Routes;
using GigaChat.Core;
using GigaChat.Data;
using GigaChat.Server.Configuration;
using GigaChat.Server.HealthChecking;
using GigaChat.Server.Logging;
using GigaChat.Server.Mapping;
using GigaChat.Server.ProblemDetails;

using Hellang.Middleware.ProblemDetails;

using Serilog;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
{
    AppConfigurationConfig.Configure(configuration, builder.Environment);
}

var host = builder.Host;
{
    host.UseSerilog(SerilogConfig.Configure);
}

var services = builder.Services;
{
    services.AddCore();
    services.AddData(configuration);
    services.AddMapper();
    services.AddHealthChecking();
    services.AddProblemDetails(ProblemDetailsConfig.Configure);
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();
{
    app.UseProblemDetails();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler(ServerRoutes.Controllers.ErrorController);
    }

    app.UseAuthorization();

    app.MapHealthChecks(ServerRoutes.HealthCheck, HealthCheckingConfig.Options);
    app.MapControllers();
}

app.Run();