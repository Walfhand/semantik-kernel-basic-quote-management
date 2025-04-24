using System.ComponentModel;
using IaPluginPoc.Models;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

namespace IaPluginPoc.Plugins;

public class QuotesPlugins
{
    [KernelFunction("get_specific_quote")]
    [Description("Get specific quote")]
    public Quote GetQuote()
    {
        return PluginsContext.Quotes.Single();
    }

    [KernelFunction("add_quote_item_to_quote")]
    [Description("Add new quote item to quote")]
    public QuoteItem AddQuoteItem([Description("id of quote")] Guid quoteId,
        [Description("The selected product")] Guid productId,
        [Description("Category of quote item. exemple : (bathroom)")]
        string category,
        [Description("Quantity of a product")] int quantity)
    {
        var product = PluginsContext.Products.Single(p => p.Id == productId);
        var quote = PluginsContext.Quotes.Single(quote => quote.Id == quoteId);
        var quoteItem = QuoteItem.Create(product.Id, category, quantity, product.Price);
        quote.AddQuoteItem(quoteItem);
        return quoteItem;
    }
}