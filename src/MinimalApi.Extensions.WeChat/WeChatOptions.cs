namespace MinimalApi.Extensions.WeChat;

public class WeChatOptions
{
    public const string HTTP_CLIENT_NAME = "wx_http_client";

    public required string AppId { get; set; }

    public required string AppSecret { get; set; }
}
