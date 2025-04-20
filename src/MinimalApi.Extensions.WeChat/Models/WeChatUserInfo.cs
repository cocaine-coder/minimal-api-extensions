using System.ComponentModel;
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
    /// 普通用户昵称
    /// </summary>
    [JsonPropertyName("nickname")]
    public required string NickName { get; init; }

    /// <summary>
    /// 普通用户性别，1为男性，2为女性
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
    /// 国家，如中国为CN
    /// </summary>
    [JsonPropertyName("country")]
    public required string Country { get; init; }

    /// <summary>
    /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空
    /// </summary>
    [JsonPropertyName("headimgurl")]
    public string? HeadImgUrl { get; init; }

    /// <summary>
    /// 用户统一标识。针对一个微信开放平台账号下的应用，同一用户的 unionid 是唯一的
    /// </summary>
    [JsonPropertyName("unionid")]
    public required string UnionId { get; init; }

    /// <summary>
    /// 用户特权信息，json数组，如微信沃卡用户为（chinaunicom）
    /// </summary>
    [JsonPropertyName("privilege")]
    public string[]? Privilege { get; init; }
}