using IaPluginPoc.Agents;
using IaPluginPoc.Config;
using IaPluginPoc.Plugins.Context;
using Microsoft.SemanticKernel;

var kernel = Kernel.CreateBuilder().AddSk();

string? userInput;
PluginsContext.InitContext();
var quoteAgent = new QuoteAgent(kernel);
do
{
    Console.Write("User > ");
    userInput = Console.ReadLine();
    if (string.IsNullOrEmpty(userInput)) userInput = PluginsContext.Quotes.Single().ProblemDescription;
    await quoteAgent.Ask(userInput);
    Console.WriteLine("");
} while (userInput is not null);