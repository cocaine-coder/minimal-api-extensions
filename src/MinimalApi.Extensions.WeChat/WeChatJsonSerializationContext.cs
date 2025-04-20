using MinimalApi.Extensions.WeChat.Models;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.WeChat;

[JsonSerializable(typeof(WeChatAccessTokenResponse))]
[JsonSerializable(typeof(WeChatUserInfo))]
public partial class WeChatJsonSerializerContext : JsonSerializerContext
{
}
