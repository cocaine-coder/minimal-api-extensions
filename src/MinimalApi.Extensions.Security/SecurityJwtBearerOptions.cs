using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MinimalApi.Extensions.Security;

public class SecurityJwtBearerOptions
{
    public string? Issuer { get; set; }

    public string? Audience { get; set; }

    public string SecretKey { get; set; } = string.Empty;

    /// <summary>
    /// default: 3600
    /// </summary>
    public int AccessTokenExpirySeconds { get; set; } = 3600;

    /// <summary>
    /// default: 7200
    /// </summary>
    public int RefreshTokenExpirySeconds { get; set; } = 7200;

    /// <summary>
    /// <para>enable get access_token from request url query param </para>
    /// <para>default: false</para>
    /// example: http://xxx.com?access_token=eyxxxxxxxxx
    /// </summary>
    public bool EnableAccessTokenInUrlQuery { get; set; }

    /// <summary>
    /// <para>get access_token from request url query param</para>
    /// <para>default: access_token</para>
    /// example: http://xxx.com?access_token=eyxxxxxxxxx
    /// </summary>
    public string AccessTokenUrlQueryKey { get; set; } = "access_token";

    /// <summary>
    /// 
    /// </summary>
    public string RefreshEndpointRole { get; set; } = "api_refresh";

    public TokenValidationParameters CreateTokenValidationParameters(bool validateLifetime)
    {
        var parameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),

            ValidateLifetime = validateLifetime,
            ClockSkew = TimeSpan.FromSeconds(AccessTokenExpirySeconds),

            ValidateIssuer = !string.IsNullOrWhiteSpace(Issuer),
            ValidIssuer = Issuer,

            ValidateAudience = !string.IsNullOrWhiteSpace(Audience),
            ValidAudience = Audience
        };

        return parameters;
    }
}
