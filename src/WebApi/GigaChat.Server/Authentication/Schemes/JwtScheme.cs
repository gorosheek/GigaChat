using System.Text;

using GigaChat.Core.Common.Services.Models;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GigaChat.Server.Authentication.Schemes;

public static class JwtScheme
{
    public const string AuthenticationScheme = JwtBearerDefaults.AuthenticationScheme;

    public static void Configure(JwtBearerOptions options, IConfiguration configuration)
    {
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>() ??
                          throw new NullReferenceException();

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };

        options.RequireHttpsMetadata = false;
    }
}