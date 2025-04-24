using IaPluginPoc.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace IaPluginPoc.Agents;

public class QuoteAgent
{
    private readonly IChatCompletionService _chatCompletionService;
    private readonly ChatHistory _history;
    private readonly Kernel _kernel;

    public QuoteAgent(Kernel kernel)
    {
        _history = [];
        _history.AddSystemMessage(SystemPrompt());
        _kernel = kernel;
        _chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
        AddPlugins();
    }

    public async Task Ask(string question)
    {
        _history.AddUserMessage(question);
        Console.Write("Assistant > ");
        var result = "";
        await foreach (var messageContent in _chatCompletionService.GetStreamingChatMessageContentsAsync(
                           _history,
                           new PromptExecutionSettings
                           {
                               FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                           },
                           _kernel))
        {
            Console.Write(messageContent.Content);
            result += messageContent.Content;
        }

        _history.AddAssistantMessage(result);
        Console.WriteLine("");
    }

    private static string SystemPrompt()
    {
        return """
               🛠️ Context
               You are an assistant integrated into a construction/renovation quotation application.

               🎯 Role
               Your role is to generate quotation line items based on a problem description.
               Example: "Client X wants to renovate their bathroom. They need a specific faucet, a certain type of tile for X square meters, etc."

               🔍 What you do

               Analyze the problem description.

               Extract the required products and, when possible, their quantities.

               If matching products exist in the database, suggest them to the client for confirmation.

               If no matching product is found, create a new item based on the description.

               Clearly state that these products were not found in the existing database.

               Always mention them explicitly using a sentence like:
               "The following products were created to match your request:" followed by the list.

               Never add any product directly to the quotation. Always ask for the client's confirmation before adding the items.

               Once the client has confirmed, add the items to the quotation.

               After items are added, provide a brief summary of the quotation, listing each item with its name, quantity, and unit price or total if available.

               ✍️ Style
               Your answers must be brief and focused, providing only the essential information.
               """;
    }

    private void AddPlugins()
    {
        _kernel.Plugins.AddFromType<ProductsPlugins>("Products");
        _kernel.Plugins.AddFromType<QuotesPlugins>("Quotes");
    }
}