using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.WeChat.Models;

public class WeChatUserInfo
{
    /// <summary>
    /// 授权用户唯一标识, 每个用户在每个应用（移动应用、网站应用、第三方平台、第三方平台api）中都不同
    /// </summary>
    [JsonPropertyName("openid")]
    public required string OpenId { get; init; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public required string NickName { get; init; }

    /// <summary>
    /// 性别
    /// </summary>
    [JsonPropertyName("sex")]
    public int Sex { get; init; }

    /// <summary>
    /// 省份
    /// </summary>
    [JsonPropertyName("province")]
    public required string Province { get; init; }

    /// <summary>
    /// 城市
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; init; }

    /// <summary>
    /// 国籍
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// 头像url，最后后台单独存储
    /// </summary>
    [JsonPropertyName("headimgurl")]
    public required string HeadImgUrl { get; init; }

    /// <summary>
    /// 用户统一标识。针对一个微信开放平台账号下的应用，同一用户的 unionid 是唯一的
    /// </summary>
    [JsonPropertyName("unionid")]
    public required string UnionId { get; init; }
}