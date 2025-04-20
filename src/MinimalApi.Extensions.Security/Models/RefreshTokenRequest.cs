namespace MinimalApi.Extensions.Security.Models;

public class RefreshTokenRequest
{
    public required string AccessToken { get; init; }
}
