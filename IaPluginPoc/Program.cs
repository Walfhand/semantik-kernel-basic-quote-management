using IaPluginPoc.Agents;
using IaPluginPoc.Config;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

var kernel = Kernel.CreateBuilder().AddSk();

string? userInput;
PluginsContext.InitContext();
Console.WriteLine("Convert problem description to quote lines ?");
Console.ReadKey();
var quoteAgent = new QuoteAgent(kernel);
await quoteAgent.Ask(PluginsContext.Quotes.Single().ProblemDescription);
do
{
    Console.Write("User > ");
    userInput = Console.ReadLine()!;
    await quoteAgent.Ask(userInput);
    Console.WriteLine("");
} while (!string.IsNullOrEmpty(userInput));