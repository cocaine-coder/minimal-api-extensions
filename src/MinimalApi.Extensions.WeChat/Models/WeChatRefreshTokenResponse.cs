using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.WeChat.Models;

public class WeChatRefreshTokenResponse
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }

    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; init; }

    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; init; }

    /// <summary>
    /// 授权用户唯一标识, 每个用户在每个应用（移动应用、网站应用、第三方平台、第三方平台api）中都不同
    /// </summary>
    [JsonPropertyName("openid")]
    public required string OpenId { get; init; }

    [JsonPropertyName("scope")]
    public required string Scope { get; init; }
}
