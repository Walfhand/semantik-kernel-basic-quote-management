using System.ComponentModel;
using IaPluginPoc.Models;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

namespace IaPluginPoc.Plugins;

public class ProductsPlugins
{
    [KernelFunction("get_products")]
    [Description("Get all of products")]
    public List<Product> GetProducts()
    {
        return PluginsContext.Products;
    }

    [KernelFunction("create_product")]
    [Description("Create new product")]
    public Product CreateProduct(string name, string description, int price, ProductQuantityUnit unit)
    {
        var product = Product.Create(name, description, price, unit);
        PluginsContext.Products.Add(product);
        return product;
    }
}