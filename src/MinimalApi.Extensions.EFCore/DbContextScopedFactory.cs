using Microsoft.EntityFrameworkCore;

namespace MinimalApi.Extensions.EFCore;

public class DbContextScopedFactory<TDbContext>(IDbContextFactory<TDbContext> pooledFactory) : IDbContextFactory<TDbContext> where TDbContext : DbContext
{
    protected virtual void OnCreateDbContext(TDbContext dbContext) { }

    public TDbContext CreateDbContext()
    {
        var context = pooledFactory.CreateDbContext();
        OnCreateDbContext(context);
        return context;
    }
}
