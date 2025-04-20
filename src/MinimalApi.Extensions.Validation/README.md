## MinimalApi.Extensions.Validation

基于 `FluentValidation` 对 `MinimalApi` endpoint 参数自动校验，并短路返回请求

### 安装

```shell
dotnet add package MinimalApi.Extensions.Validation
```

### 配置

```csharp
// 需要提前注册所有的validator，FluentValidation提供了反射注入
// 如果你需要aot版本，在文档下面会介绍

services.AddAutoValidation();

// 自定义返回
services.AddAutoValidation(o =>
{
    o.ValidationResultCreator = (validationResult, httpContext) =>
    {
        httpContext.Response.StatusCode = StatusCodes.Status200OK;
        return validationResult.Errors;
    };
});
```

### 使用

```csharp
public class Cat
{
    public string Name { get; set; }
}

public class CatValidator : AbstractValidator<Cat>
{
    public CatValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(8);
    }
}

app.MapPost("create-cat", (Cat cat) =>
{
    return TypedResults.Ok(cat);
}).AddValidationFilter();
```

**泛型版本**
```csharp
app.MapPost("create-cat", (Cat cat) =>
{
    return TypedResults.Ok(cat);
}).AddValidationFilter<Cat>();
```

### 说明
1. 非泛型版本会将所有 `endpoint` 传入的 `class` 参数查找对应的 `validator`
2. 如果想使用 `aot` 注入所有的 `validator`，请安装 `MinimalApi.Extensions.SourceGeneration` 库

### aot 注入 validator

**安装并设置代码生成器**
```xml
<ItemGroup>
 <PackageReference Include="MinimalApi.Extensions.SourceGeneration"  OutputItemType="Analyzer" ReferenceOutputAssembly="false"/>
</ItemGroup>
```

**代码注入**

```csharp
builder.Services.AddAutoValidation()
// 自动注入所有的validator
.RegisterAllValidators();
```