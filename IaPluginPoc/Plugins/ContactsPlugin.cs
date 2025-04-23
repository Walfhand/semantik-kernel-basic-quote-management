using System.ComponentModel;
using IaPluginPoc.Models;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

namespace IaPluginPoc.Plugins;

public class ContactsPlugin
{
    [KernelFunction("create_new_contact")]
    [Description("Create a new contact")]
    public Contact CreateContact([Description("firstname of contact")] string firstname, [Description("lastname of contact")] string lastname)
    {
        var newContact = new Contact
        {
            Id = Guid.NewGuid(),
            Firstname = firstname,
            Lastname = lastname
        };
        PluginsContext.Contacts.Add(newContact);
        return newContact;
    }

    [KernelFunction("get_existing_contacts")]
    [Description("Get list of existing contacts")]
    public List<Contact> GetContacts()
    {
        return PluginsContext.Contacts;
    }
}