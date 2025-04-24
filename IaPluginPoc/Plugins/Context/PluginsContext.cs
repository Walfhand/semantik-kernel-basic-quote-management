using IaPluginPoc.Models;

namespace IaPluginPoc.Plugins.Context;

public static class PluginsContext
{
    public static readonly List<Product> Products = [];
    public static readonly List<Quote> Quotes = [];

    public static void InitContext()
    {
        Quotes.Add(Quote.CreateMinimalValidQuote());
    }
}