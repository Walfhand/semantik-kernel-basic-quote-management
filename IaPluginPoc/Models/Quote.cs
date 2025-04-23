using System.Text.Json.Serialization;

namespace IaPluginPoc.Models;

public class Quote
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    [JsonPropertyName("person_customer")]
    public PersonCustomer? PersonCustomer { get; set; }
    
    [JsonPropertyName("organization_customer")]
    public OrganizationCustomer? OrganizationCustomer { get; set; }
    
    [JsonPropertyName("contact")]
    public Contact? Contact { get; set; }

    public void LinkContact(Contact contact)
    {
        Contact = contact;
    }

    public void LinkOrganizationCustomer(OrganizationCustomer organizationCustomer)
    {
        OrganizationCustomer = organizationCustomer;
    }

    public void LinkPersonCustomer(PersonCustomer personCustomer)
    {
        PersonCustomer = personCustomer;
    }
}