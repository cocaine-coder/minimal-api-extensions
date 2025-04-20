using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MinimalApi.Extensions.EFCore;

public static class Extensions
{
    public static IServiceCollection AddPooledDbContext<TDbContext, TDbContextScopedFactory>(
        this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction, int poolSize = 1024)
        where TDbContext : DbContext
        where TDbContextScopedFactory : DbContextScopedFactory<TDbContext>
    {
        services.AddPooledDbContextFactory<TDbContext>(builder => {
            builder.UseSnakeCaseNamingConvention();
#if DEBUG
            builder.EnableSensitiveDataLogging();
#endif
            optionsAction(builder);
        }, poolSize);

        services.AddScoped<TDbContextScopedFactory>();
        services.AddScoped(static sp =>
        {
            return sp.GetRequiredService<TDbContextScopedFactory>().CreateDbContext();
        });

        return services;
    }
}
