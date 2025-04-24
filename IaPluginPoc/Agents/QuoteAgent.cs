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

               When creating new products, add them directly as quote items in the quotation.

               Optionally, provide a short summary listing the created items and mention that they were not found in the product database. This summary is not required every time — only when it adds value.

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