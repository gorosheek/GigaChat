using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using GigaChat.Core.Common.Services.Interfaces;
using GigaChat.Core.Common.Services.Models;
using GigaChat.Core.Common.Entities.Users;

using IdentityModel;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GigaChat.Core.Common.Services.Realisations;

public class JwtTokenProvider : IJwtTokenProvider
{
    private readonly JwtSettings _jwtSettings;
    private readonly IDateTimeProvider _dateTimeProvider;

    public JwtTokenProvider(IOptions<JwtSettings> jwtSettings, IDateTimeProvider dateTimeProvider)
    {
        _jwtSettings = jwtSettings.Value;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<string> GenerateTokenAsync(User user, CancellationToken cancellationToken = default)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Subject, user.Id.ToString()),
            new Claim(JwtClaimTypes.Name, user.Name),
            new Claim(JwtClaimTypes.NickName, user.Login)
        };

        var currentTime = await _dateTimeProvider.GetUtcNowAsync(cancellationToken);

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: currentTime.AddMinutes(_jwtSettings.ExpiryMinutes).UtcDateTime,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
                SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<bool> IsExpiredAsync(string token, CancellationToken cancellationToken = default)
    {
        var currentTime = await _dateTimeProvider.GetUtcNowAsync(cancellationToken);
        var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);
        return jwt.ValidTo < currentTime;
    }
}