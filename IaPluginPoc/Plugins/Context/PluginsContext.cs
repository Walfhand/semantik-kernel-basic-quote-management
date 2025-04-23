using IaPluginPoc.Models;

namespace IaPluginPoc.Plugins.Context;

public class PluginsContext
{
    public static readonly List<Contact> Contacts =
    [
        new()
        {
            Id = Guid.NewGuid(),
            Firstname = "Marc",
            Lastname = "Vandaele",
        }
    ];

    public static readonly List<Quote> Quotes = [];
    public static readonly List<PersonCustomer> PersonCustomers = [];
    public static readonly List<OrganizationCustomer>  OrganizationCustomers = [];
}