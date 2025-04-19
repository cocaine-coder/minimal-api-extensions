using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MinimalApi.Extensions.Security;

public class CustomJwtBearerOptions
{
    public string? Issuer { get; init; }

    public string? Audience { get; init; }

    public required string SecretKey { get; init; }

    /// <summary>
    /// default: 3600
    /// </summary>
    public int AccessTokenExpirySeconds { get; init; } = 3600;

    /// <summary>
    /// default: 7200
    /// </summary>
    public int RefreshTokenExpirySeconds { get; init; } = 7200;

    /// <summary>
    /// <para>enable get access_token from request url query param </para>
    /// <para>default: false</para>
    /// example: http://xxx.com?access_token=eyxxxxxxxxx
    /// </summary>
    public bool EnableAccessTokenInUrlQuery { get; init; }

    /// <summary>
    /// <para>get access_token from request url query param</para>
    /// <para>default: access_token</para>
    /// example: http://xxx.com?access_token=eyxxxxxxxxx
    /// </summary>
    public string AccessTokenUrlQueryKey { get; init; } = "access_token";

    /// <summary>
    /// 
    /// </summary>
    public string RefreshEndpointRole { get; init; } = "api_refresh";

    public TokenValidationParameters CreateTokenValidationParameters(bool validateLifetime)
    {
        var parameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            ValidateLifetime = validateLifetime,

            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
            ClockSkew = TimeSpan.FromSeconds(AccessTokenExpirySeconds),
        };

        if (Issuer is not null)
        {
            parameters.ValidateIssuer = true;
            parameters.ValidIssuer = Issuer;
        }

        if (Audience is not null)
        {
            parameters.ValidateAudience = true;
            parameters.ValidAudience = Audience;
        }

        return parameters;
    }
}
