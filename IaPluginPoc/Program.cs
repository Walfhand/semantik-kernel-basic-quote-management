using IaPluginPoc.Agents;
using IaPluginPoc.Config;
using Microsoft.SemanticKernel;

var kernel = Kernel.CreateBuilder().AddSk();

string? userInput;
var quoteAgent = new QuoteAgent(kernel);
do {
    Console.Write("User > ");
    userInput = Console.ReadLine();
    await quoteAgent.Ask(userInput!);
    Console.WriteLine("");
} while (userInput is not null);
