## MinimalApi.Extensions.HttpResults

如果你是200党，你就用吧

### 安装
```shell
dotnet add package MinimalApi.Extensions.HttpResults
```

### 使用

```csharp
app.MapGet("result-ok", () =>
{
    var res = new XXDot()
    {
        Name = "xxx",
        Age = 12
    };
    return TypedResults.Extensions.Ok(res);  
    // { "success":true, "data":{"name":"xxx", "age":12} }
});

app.MapGet("result-ok-null", () =>
{
    return TypedResults.Extensions.Ok();    
    // { "success":true, "data":null }
});

app.MapGet("result-bad", () =>
{
    return TypedResults.Extensions.Bad("something wrong");   
    // { "success":false, "error":"something wrong" }      
});

app.MapGet("result-bad-code", () =>
{
    return TypedResults.Extensions.Bad(1001 ,"something wrong");   
    // { "success":false, "code" : 1001, "error":"something wrong" }
});
```

### 说明
1. 支持 `aot` 编译
2. 仅 `Ok` 方法支持 `OpenApi` 生成文档，文档生成传入参数的模型架构