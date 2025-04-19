namespace MinimalApi.Extensions.Security;

public class JwtTokenResponse
{
    public required string AccessToken { get; init; }

    public required string RefreshToken { get; init; }

    public DateTime AccessTokenExpiries { get; init; }

    public DateTime RefreshTokenExpiries { get; init; }
}