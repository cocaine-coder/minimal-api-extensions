## MinimalApi.Extensions.Security

基于 `JwtBearer` 生成 `AccessToken` 及 `RefreshToken`

### 安装
```shell
dotnet add package MinimalApi.Extensions.Security
```

### 配置

```csharp
builder.Services.AddJwtBearer(new SecurityJwtBearerOptions()
{
    SecretKey = "1234567890qwertyuiopasdfghjklzxcvbnm",
    
    // 以下选填
    Issuer = "http://localhost:5000",
    Audience = "http://localhost:5000",
    AccessTokenExpirySeconds = 10 * 60,            // 默认3600
    RefreshTokenExpirySeconds = 7 * 24 * 60 * 60,  // 默认7200
    EnableAccessTokenInUrlQuery = true,            // 默认false              启用url中获取accesstoken
    AccessTokenUrlQueryKey = "access_token",       // 默认access_token       参数的key
    RefreshEndpointRole = "api_refresh_token"      // 默认api_refresh_token  refreshtoken claim role
});

// 从配置中读取
builder.Services.AddJwtBearer(builder.Configuration.GetSection("Jwt"));
```
### 使用
```csharp
app.MapPost("login", ([FromServices] SecurityJwtTokenService jwtTokenService) =>
{
    return TypedResults.Ok(jwtTokenService.GenerateToken([
        new Claim("userid", "1")
    ]));
});
```

### 说明
1. 支持 `aot` 编译
2. 出于性能考虑，使用单例注入