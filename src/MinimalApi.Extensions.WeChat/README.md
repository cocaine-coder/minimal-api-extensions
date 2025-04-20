## MinimalApi.Extensions.WeChat

微信 `网站应用` [openapi](https://developers.weixin.qq.com/doc/oplatform/Website_App/WeChat_Login/Wechat_Login.html)

### 准备 

微信开放平台注册开发者账号，并拥有一个已审核通过的网站应用，并获得相应的AppID和AppSecret

### 安装

```shell
dotnet add package MinimalApi.Extensions.WeChat
```

### 配置

两种配置方式：

1. 代码中填写
```csharp
using MinimalApi.Extensions.WeChat;

services.AddWeChatService(o=>
{
	o.AppId = "xxx";
	o.AppSecret = "xxxxx";
});
```

2. 配置文件中配置(提供IConfiguration)
```json
{
	"WeChat":{
		"AppId" : "xxx",
		"AppSecret" : "xxxxxx"
	}
}
```

```csharp
services.AddWeChatService(configuration.GetSection("WeChat"));
```

### 使用

```csharp
app.MapGet("login",async ([FromService] WeChatService weChatService, string code)=>{
    var response = await weChatService.GetAccessTokenAsync(code);
	return Results.Ok(response);
});
```

### api 列表

| 方法名 | 作用 | 
| - | - | 
| GetAccessTokenAsync | 通过code获取网站授权 access_token |
| RefreshAccessTokenAsync | 刷新或续期网站授权 access_token 使用 |
| GetUserInfoAsync | 获取用户信息 |

### 说明

1. 支持 `aot` 编译
2. 注册了名字为 `wx_http_client` 的 `HttpClient`, 请不要覆盖注册, 通过 `httpClientFactory.CreateClient(WeChatOptions.HTTP_CLIENT_NAME)` 获取 `HttpClient` 实例
3. 可以通过注入 `IOptions<WeChatOptions>` 获取配置
4. 为了性能考虑，`WeChatService` 被注册为单例