using Microsoft.Extensions.Options;
using MinimalApi.Extensions.WeChat.Models;
using System.Net.Http.Json;

namespace MinimalApi.Extensions.WeChat;

public class WeChatService(IOptions<WeChatOptions> options, IHttpClientFactory httpClientFactory)
{
    /// <summary>
    /// 通过code获取网站授权 access_token
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public Task<WeChatAccessTokenResponse?> GetAccessTokenAsync(string code)
    {
        return RequestWeChatApi<WeChatAccessTokenResponse>(
            $"/sns/oauth2/access_token?appid={options.Value.AppId}&secret={options.Value.AppSecret}&code={code}&grant_type=authorization_code");
    }

    /// <summary>
    /// 刷新或续期网站授权 access_token 使用
    /// </summary>
    /// <param name="refreshToken"></param>
    /// <returns></returns>
    public Task<WeChatRefreshTokenResponse?> RefreshAccessTokenAsync(string refreshToken)
    {
        return RequestWeChatApi<WeChatRefreshTokenResponse>(
            $"/sns/oauth2/refresh_token?appid=${options.Value.AppId}&grant_type=refresh_token&refresh_token={refreshToken}");
    }

    /// <summary>
    /// 获取用户信息
    /// </summary>
    /// <param name="accessToken"></param>
    /// <param name="openId"></param>
    /// <returns></returns>
    public Task<WeChatUserInfo?> GetUserInfoAsync(string accessToken, string openId)
    {
        return RequestWeChatApi<WeChatUserInfo>($"/sns/userinfo?access_token={accessToken}&openid={openId}");
    }

    private async Task<TResult?> RequestWeChatApi<TResult>(string uri) where TResult : class
    {
        var client = httpClientFactory.CreateClient(WeChatOptions.HTTP_CLIENT_NAME);
        var response = await client.GetFromJsonAsync<TResult>(uri);
        return response;
    }
}