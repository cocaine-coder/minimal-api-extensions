# MinimalApi.Extensions.EFCore

EFCore 经常使用的扩展

```shell
dotnet add package MinimalApi.Extensions.EFCore
```

## 池化DbContext

```csharp
// 创建 DbContext 类
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public string TenantId {get; set;}
}

// 继承重写 DbContextScopedFactory
public class AppDbContextScopedFactory(IDbContextFactory<TDbContext> pooledFactory, ITenantService tenantService) : DbContextScopedFactory<AppDbContext>(pooledFactory)
{
    protected override void OnCreateDbContext(AppDbContext dbContext)
    {
        dbContext.TenantId = tenantService.Id;
    }
}

// 注册
services.AddPooledDbContext<AppDbContext, AppDbContextScopedFactory>(builder=>
{
    builder.UseNpgsql("xxxx");
});

```