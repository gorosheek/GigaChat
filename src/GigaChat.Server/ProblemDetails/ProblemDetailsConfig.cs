using ProblemDetailsOptions = Hellang.Middleware.ProblemDetails.ProblemDetailsOptions;

namespace GigaChat.Server.ProblemDetails;

public static class ProblemDetailsConfig
{
    public static void Configure(ProblemDetailsOptions options)
    {
        options.IncludeExceptionDetails = (_, _) => false;
    }
}