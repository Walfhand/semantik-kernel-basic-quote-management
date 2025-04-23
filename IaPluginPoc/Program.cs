using IaPluginPoc.Agents;
using Microsoft.SemanticKernel;

var builder = Kernel.CreateBuilder().AddOpenAIChatCompletion("gpt-4.1",
    new Uri("https://api.openai.com/v1"),
    "",
    serviceId: "code");

Kernel kernel = builder.Build();

string? userInput;
var quoteAgent = new QuoteAgent(kernel);
do {
    Console.Write("User > ");
    userInput = Console.ReadLine();
    await quoteAgent.Ask(userInput!);
    Console.WriteLine("");
} while (userInput is not null);
