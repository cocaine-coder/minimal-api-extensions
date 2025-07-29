using MinimalApi.Extensions.Attributes;

namespace MinimalApi.Extensions.Example.Contracts.Configuration;

[AutoConfigOption("OSS")]
public class OSSConfiguration
{
    public required string AppKey { get; set; }

    public required string AppSecret { get; set; }
}
