namespace MinimalApi.Extensions.Security;

public class RefreshTokenRequest
{
    public required string AccessToken { get; init; }
}
