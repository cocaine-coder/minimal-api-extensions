namespace MinimalApi.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AutoConfigOptionAttribute(string section) : Attribute
{
    public string Section { get; } = section;
}
