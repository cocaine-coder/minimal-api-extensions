namespace MinimalApi.Extensions.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
public class AutoConfigOptionAttribute(string section) : Attribute
{
    public string Section { get; } = section;
}