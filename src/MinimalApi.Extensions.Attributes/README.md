# MinimalApi.Extensions.Attributes

一些好玩的attributes，经常与 [MinimalApi.Extensions.SourceGeneration](https://www.nuget.org/packages/MinimalApi.Extensions.SourceGeneration) 配合使用，之后考虑增加一些验证类的Attribute

## AutoConfigOptionAttribute
标记`class`或`struct`，接受参数 `section` 自动生成 `services.Configure<XXX>(configuration.GetSection("[section]"))` 代码

## AutoDependencyInjectionAttribute
标记`class`, 自动生成依赖注入代码

*参数*
- Lifetime 生命周期
```
[AutoDependencyInjection(ServiceLifetime.Scoped)]
public class XXX {}

...


// 生成代码
services.AddScoped<XXX>();
```

- InterfaceTypes 实现的接口
```
public interface A {}
public interface B {}

[AutoDependencyInjection(ServiceLifetime.Scoped, InterfaceTypes = [typeof(A), typeof(B)])]
public class XXX : A , B {}

...

// 生成代码
services.AddScoped<A, XXX>();
services.AddScoped<B, XXX>();
```

- Key 注册为Keyd服务，并使用该参数作为key
```
public interface A {}

[AutoDependencyInjection(ServiceLifetime.Scoped, InterfaceTypes = [typeof(A)], Key = "1")]
public class XXX1 : A {}
[AutoDependencyInjection(ServiceLifetime.Scoped, InterfaceTypes = [typeof(A)], Key = "2")]
public class XXX2 : A {}

...

// 生成代码
services.AddScoped<A, XXX1>("1");
services.AddScoped<A, XXX2>("2");
```
- UseTry
```
[AutoDependencyInjection(ServiceLifetime.Scoped, UseTry = true)]
public class XXX {}

...


// 生成代码
services.TryAddScoped<XXX>();
```