using Microsoft.Extensions.Options;
using MinimalApi.Extensions.WeChat.Models;
using System.Net.Http.Json;

namespace MinimalApi.Extensions.WeChat;

public class WeChatService (IOptions<WeChatOptions> options, IHttpClientFactory httpClientFactory)
{
    public async Task<WeChatAccessTokenResponse?> GetAccessTokenAsync(string code)
    {
        using var client = httpClientFactory.CreateClient(WeChatOptions.HTTP_CLIENT_NAME);
        var response = await client.GetFromJsonAsync<WeChatAccessTokenResponse>(
            $"/sns/oauth2/access_token?appid={options.Value.AppId}&secret={options.Value.AppSecret}&code={code}&grant_type=authorization_code"
        );
        return response;
    }

    public async Task<WeChatUserInfo?> GetUserInfoAsync(string accessToken, string openId)
    {
        using var client = httpClientFactory.CreateClient(WeChatOptions.HTTP_CLIENT_NAME);
        var response = await client.GetFromJsonAsync<WeChatUserInfo>(
            $"/sns/userinfo?access_token={accessToken}&openid={openId}"
        );
        return response;
    }
}