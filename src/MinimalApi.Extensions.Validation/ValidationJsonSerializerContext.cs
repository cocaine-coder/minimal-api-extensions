using FluentValidation.Results;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.Validation;

[JsonSerializable(typeof(List<ValidationFailure>))]
[JsonSerializable(typeof(Dictionary<string, string[]>))]
public partial class ValidationJsonSerializerContext : JsonSerializerContext
{
}
