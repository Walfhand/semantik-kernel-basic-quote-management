namespace IaPluginPoc.Models;

public class PersonCustomer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Lang Lang { get; set; }
    public Salutation Salutation { get; set; }
}

public class OrganizationCustomer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public OrganizationType Type { get; set; }
    public string Email { get; set; } = null!;
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
    Miss
}