using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.Security;

public static class JwtBearerExtensions
{
    public static IServiceCollection AddJwtBearer(
        this IServiceCollection services,
        IConfiguration configuration,
        Action<JwtBearerOptions>? jwtBearerOptionsAction = default,
        Action<AuthorizationOptions>? authorizationOptionsAction = default)
    {
        var options = configuration.Get<SecurityJwtBearerOptions>();
        if(options == null) throw new NullReferenceException(nameof(options));

        return AddJwtBearer(services, options, jwtBearerOptionsAction, authorizationOptionsAction);
    }

    /// <summary>
    /// <a href="https://learn.microsoft.com/zh-cn/aspnet/core/fundamentals/minimal-apis/security?view=aspnetcore-9.0">配置文档</a>
    /// </summary>
    /// <param name="services"></param>
    /// <param name="options"></param>
    /// <param name="jwtBearerOptionsAction"></param>
    /// <param name="authorizationOptionsAction"></param>
    /// <returns></returns>
    public static IServiceCollection AddJwtBearer(
        this IServiceCollection services,
        SecurityJwtBearerOptions options,
        Action<JwtBearerOptions>? jwtBearerOptionsAction = default,
        Action<AuthorizationOptions>? authorizationOptionsAction = default)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.TokenValidationParameters = options.CreateTokenValidationParameters(true);

            if (options.EnableAccessTokenInUrlQuery)
            {
                o.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query[options.AccessTokenUrlQueryKey];
                        if (!string.IsNullOrEmpty(accessToken))
                        {
                            context.Token = accessToken;
                        }

                        return Task.CompletedTask;
                    }
                };
            }

            jwtBearerOptionsAction?.Invoke(o);
        });

        if(authorizationOptionsAction is not null)
        {
            services.AddAuthorization(authorizationOptionsAction);
        }
        else
        {
            services.AddAuthorization();
        }

        services.ConfigureHttpJsonOptions(o =>
        {
            o.SerializerOptions.TypeInfoResolverChain.Insert(0, SecurityJsonSerializerContext.Default);
        });

        services.AddSingleton(options);
        services.AddSingleton<SecurityJwtTokenService>();

        return services;
    }
}
