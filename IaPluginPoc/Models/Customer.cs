using System.Text.Json.Serialization;

namespace IaPluginPoc.Models;

public class PersonCustomer
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [JsonPropertyName("first_name")]
    public string Firstname { get; set; } = null!;
    [JsonPropertyName("last_name")]
    public string Lastname { get; set; } = null!;
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
    [JsonPropertyName("phone_number")]
    public string Phone { get; set; } = null!;
    [JsonPropertyName("lang")]
    public Lang Lang { get; set; }
    [JsonPropertyName("salutation")]
    public Salutation Salutation { get; set; }
}

public class OrganizationCustomer
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    [JsonPropertyName("type")]
    public OrganizationType Type { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; } = null!;
    [JsonPropertyName("phone_number")]
    public string Phone { get; set; } = null!;
}

public enum Lang
{
    Fr,
    En,
    Nl
}


public enum OrganizationType
{
    Prospect,
    Insurance,
    BusinessProvider
}
public enum Salutation
{
    Mr,
    Miss,
}