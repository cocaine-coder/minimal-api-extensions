using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.WeChat;

public static class Extensions
{
    public static IServiceCollection AddWeChatService(this IServiceCollection services, Action<WeChatOptions> optionsAction)
    {
        services.Configure(optionsAction);
        return AddWeChatService(services);
    }

    public static IServiceCollection AddWeChatService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<WeChatOptions>(configuration);
        return AddWeChatService(services);
    }

    private static IServiceCollection AddWeChatService(IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(o =>
        {
            o.SerializerOptions.TypeInfoResolverChain.Insert(0, WeChatJsonSerializerContext.Default);
        });

        services.AddHttpClient(WeChatOptions.HTTP_CLIENT_NAME, httpClient =>
        {
            httpClient.BaseAddress = new Uri("https://api.weixin.qq.com");
        });

        services.AddSingleton<WeChatService>();

        return services;
    }
}
