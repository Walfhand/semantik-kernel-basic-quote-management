namespace IaPluginPoc.Models;

public class QuoteItem
{
    private QuoteItem(Guid productId, string category, int quantity, int unitPrice)
    {
        ProductId = productId;
        Category = category;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Price = unitPrice * quantity;
    }

    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Category { get; private set; }
    public int Quantity { get; private set; }
    public int UnitPrice { get; private set; }
    public Guid ProductId { get; private set; }
    public int Price { get; private set; }


    public static QuoteItem Create(Guid productId, string category, int quantity, int unitPrice)
    {
        return new QuoteItem(productId, category, quantity, unitPrice);
    }

    public void Update(Guid productId, string category, int quantity, int unitPrice)
    {
        ProductId = productId;
        Category = category;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Price = unitPrice * quantity;
    }
}