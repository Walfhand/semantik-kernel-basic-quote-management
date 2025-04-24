namespace IaPluginPoc.Models;

public class Product
{
    private Product(string name, string description, int price, ProductQuantityUnit unit)
    {
        Name = name;
        Price = price;
        Unit = unit;
        Description = description;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public int Price { get; private set; }
    public ProductQuantityUnit Unit { get; private set; }
    public string Description { get; private set; }

    public static Product Create(string name, string description, int price, ProductQuantityUnit unit)
    {
        return new Product(name, description, price, unit);
    }

    public void Update(string name, string description, int price, ProductQuantityUnit unit)
    {
        Name = name;
        Description = description;
        Price = price;
        Unit = unit;
    }
}

public enum ProductQuantityUnit
{
    SquareMeter,
    CubicMeter,
    Item
}