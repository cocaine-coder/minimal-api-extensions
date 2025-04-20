using MinimalApi.Extensions.Security.Models;
using System.Text.Json.Serialization;

namespace MinimalApi.Extensions.Security;

[JsonSerializable(typeof(RefreshTokenRequest))]
[JsonSerializable(typeof(JwtTokenResponse))]
public partial class SecurityJsonSerializerContext : JsonSerializerContext
{
}
