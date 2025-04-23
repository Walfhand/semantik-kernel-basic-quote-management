using IaPluginPoc.Models;

namespace IaPluginPoc.Plugins.Context;

public class PluginsContext
{
    public static List<Contact> Contacts =
    [
        new Contact
        {
            Id = Guid.NewGuid(),
            Firstname = "Marc",
            Lastname = "Vandaele",
        }
    ];

    public static List<Quote> Quotes = [];
    public static List<PersonCustomer> PersonCustomers = [];
    public static List<OrganizationCustomer>  OrganizationCustomers = [];
}