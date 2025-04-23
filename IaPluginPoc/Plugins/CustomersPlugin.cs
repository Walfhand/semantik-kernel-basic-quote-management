using System.ComponentModel;
using IaPluginPoc.Models;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

namespace IaPluginPoc.Plugins;

public class CustomersPlugin
{
    
    [KernelFunction("get_person_customers")]
    [Description("Get person customers")]
    public List<PersonCustomer> GetPersonCustomers()
    {
        return PluginsContext.PersonCustomers;
    }
    
    [KernelFunction("get_organizations_customers")]
    [Description("Get organizations customers")]
    public List<OrganizationCustomer> GetOrganizationCustomers()
    {
        return PluginsContext.OrganizationCustomers;
    }
    
    [KernelFunction("create_new_person_customer")]
    [Description("Create a new person customer.")]
    public PersonCustomer CreatePersonCustomer([Description("First name")]string firstName, 
        [Description("Last name")]string lastName, [Description("email")]string email, 
        [Description("Phone") ]string phone, [Description("Lang")]Lang lang, [Description("Salutation")]Salutation salutation)
    {
        var personCustomer = new PersonCustomer
        {
            Firstname = firstName,
            Lastname = lastName,
            Email = email,
            Lang = lang,
            Phone = phone,
            Salutation = salutation
        };
        PluginsContext.PersonCustomers.Add(personCustomer);
        return personCustomer;
    }
    
    [KernelFunction("create_new_organization_customer")]
    [Description("Create a new organization customer.")]
    public OrganizationCustomer CreateOrganizationCustomer(
        [Description("name")]string name, [Description("Type")]OrganizationType type, [Description("email")]string email, 
        [Description("Phone") ]string phone)
    {
        var organPersonCustomer = new OrganizationCustomer
        {
            Email = email,
            Phone = phone,
            Name = name,
            Type = type
        };
        PluginsContext.OrganizationCustomers.Add(organPersonCustomer);
        return organPersonCustomer;
    }
}