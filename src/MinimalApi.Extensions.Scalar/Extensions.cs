using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;

namespace MinimalApi.Extensions.Scalar;

public static class Extensions
{
    public static IServiceCollection AddScalar(this IServiceCollection services, Action<CustomScalarOptions>? optionsConfigure = default)
    {
        var options = new CustomScalarOptions();
        optionsConfigure?.Invoke(options);

        services.AddOpenApi(opt =>
        {
            if (options.UseJwtBearer)
            {
                opt.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
            }

            opt.AddDocumentTransformer((doc, ctx, _) =>
            {
                doc.Info = new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = options.Title,
                    Description = options.Description,
                    Version = options.Version
                };

                return Task.CompletedTask;
            });
        });
        return services;
    }

    public static WebApplication MapScalar(this WebApplication webApplication)
    {
        webApplication.MapScalarApiReference();
        webApplication.MapOpenApi();

        return webApplication;
    }
}
