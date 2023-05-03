using GigaChat.Core;
using GigaChat.Data;
using GigaChat.Server.Mapping;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
{
    services.AddCore();
    services.AddData(builder.Configuration);
    services.AddMapper();
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();