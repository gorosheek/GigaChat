using GigaChat.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GigaChat.Migrations;

public class Factory : IDesignTimeDbContextFactory<GigaChatDbContext>
{
    public GigaChatDbContext CreateDbContext(string[] args)
    {
        var configurationBuilder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddUserSecrets<Factory>()
            .AddEnvironmentVariables();

        var configuration = configurationBuilder.Build();
        var optionsBuilder = new DbContextOptionsBuilder<GigaChatDbContext>();
        GigaChatDbContext.Configure(optionsBuilder, configuration, typeof(Factory).Assembly);

        return new GigaChatDbContext(optionsBuilder.Options);
    }
}