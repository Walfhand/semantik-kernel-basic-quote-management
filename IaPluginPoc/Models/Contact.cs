namespace IaPluginPoc.Models;

public record Contact
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
}