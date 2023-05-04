using Serilog;

namespace GigaChat.Server.Logging;

public static class SerilogConfig
{
    public static void Configure(
        HostBuilderContext context,
        LoggerConfiguration loggingBuilder)
    {
        loggingBuilder.ReadFrom.Configuration(context.Configuration);
    }
}