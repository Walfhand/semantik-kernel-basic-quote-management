using System.ComponentModel;
using IaPluginPoc.Models;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

namespace IaPluginPoc.Plugins;
public class QuotesPlugins
{
    [KernelFunction("create_empty_quote")]
    [Description("Create a new empty quote")]
    public Quote CreateEmptyQuote()
    {
        var emptyQuote = new Quote();
        PluginsContext.Quotes.Add(emptyQuote);
        return emptyQuote;
    }
    

    [KernelFunction("link_contact_to_quote")]
    [Description("Link an existing contact to the quote")]
    public void LinkContactToQuote([Description("Id of quote")] Guid quoteId, [Description("Id of contact")] Guid contactId)
    {
        var contact = PluginsContext.Contacts.SingleOrDefault(contact => contact.Id == contactId);
        if (contact is null)
            throw new Exception();
        var quote =  PluginsContext.Quotes.SingleOrDefault(quote => quote.Id == quoteId);
        if (quote is null)
            throw new Exception();
        quote.LinkContact(contact);
    }
    
    [KernelFunction("link_person_customer_to_quote")]
    [Description("Link an existing person customer to the quote")]
    public void LinkPersonCustomerToQuote([Description("Id of quote")] Guid quoteId, [Description("Id of person customer")] Guid personCustomerId)
    {
        var personCustomer = PluginsContext.PersonCustomers.SingleOrDefault(personCustomer => personCustomer.Id == personCustomerId);
        if (personCustomer is null)
            throw new Exception();
        var quote =  PluginsContext.Quotes.SingleOrDefault(quote => quote.Id == quoteId);
        if (quote is null)
            throw new Exception();
        quote.LinkPersonCustomer(personCustomer);
    }
    
    [KernelFunction("link_organization_customer_to_quote")]
    [Description("Link an existing person customer to the quote")]
    public void LinkOrganizationCustomerToQuote([Description("Id of quote")] Guid quoteId, 
        [Description("Id of organization customer")] Guid organizationCustomerId)
    {
        var organizationCustomer = PluginsContext.OrganizationCustomers.SingleOrDefault(organizationCustomer => organizationCustomer.Id == organizationCustomerId);
        if (organizationCustomer is null)
            throw new Exception();
        var quote =  PluginsContext.Quotes.SingleOrDefault(quote => quote.Id == quoteId);
        if (quote is null)
            throw new Exception();
        quote.LinkOrganizationCustomer(organizationCustomer);
    }
}