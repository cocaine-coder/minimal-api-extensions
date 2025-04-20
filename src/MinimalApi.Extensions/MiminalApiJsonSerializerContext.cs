using FluentValidation.Results;
using MinimalApi.Extensions.Security;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions;

[JsonSerializable(typeof(List<ValidationFailure>))]
[JsonSerializable(typeof(Dictionary<string, string[]>))]
[JsonSerializable(typeof(JwtTokenResponse))]
public partial class MiminalApiJsonSerializerContext : JsonSerializerContext
{
}