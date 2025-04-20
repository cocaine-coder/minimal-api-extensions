using Microsoft.IdentityModel.Tokens;
using MinimalApi.Extensions.Security.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MinimalApi.Extensions.Security;

public class SecurityJwtTokenService(SecurityJwtBearerOptions options)
{
    public JwtTokenResponse GenerateToken(IEnumerable<Claim>? claims = default)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SecretKey));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var now = DateTime.Now;
        var accessTokenExpiries = now.AddSeconds(options.AccessTokenExpirySeconds);
        var refreshTokenExpiries = now.AddSeconds(options.RefreshTokenExpirySeconds);

        var accessToken = new JwtSecurityToken(
            options.Issuer,
            options.Audience,
            claims,
            now,
            accessTokenExpiries,
            signingCredentials);

        var refreshToken = new JwtSecurityToken(
            options.Issuer,
            options.Audience,
            [new Claim(ClaimTypes.Role, options.RefreshEndpointRole)],
            now,
            refreshTokenExpiries,
            signingCredentials);

        return new JwtTokenResponse()
        {
            AccessToken = jwtSecurityTokenHandler.WriteToken(accessToken),
            RefreshToken = jwtSecurityTokenHandler.WriteToken(refreshToken),
            AccessTokenExpiries = accessTokenExpiries,
            RefreshTokenExpiries = refreshTokenExpiries
        };
    }

    public JwtTokenResponse? RefreshToken<T>(T request) where T : RefreshTokenRequest
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        if (!jwtSecurityTokenHandler.CanReadToken(request.AccessToken))
        {
            return null;
        }

        #region valid access token
        var validateParameter = options.CreateTokenValidationParameters(false);

        SecurityToken? validatedToken;
        try
        {
            jwtSecurityTokenHandler.ValidateToken(request.AccessToken, validateParameter, out validatedToken);
        }
        catch
        {
            return null;
        }

        #endregion

        if (validatedToken is JwtSecurityToken jwtToken)
        {
            return GenerateToken(jwtToken.Claims);
        }

        return null;
    }
}
