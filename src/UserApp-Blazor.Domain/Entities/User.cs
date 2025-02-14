using System.Text.Json.Serialization;

namespace UserApp_Blazor.Domain.Entities;

public class User
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("about")]
    public string About { get; set; }
}