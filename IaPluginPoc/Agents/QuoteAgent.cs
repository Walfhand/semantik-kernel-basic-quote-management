using IaPluginPoc.Plugins;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

namespace IaPluginPoc.Agents;

public class QuoteAgent
{
    private readonly ChatHistory _history;
    private readonly Kernel _kernel;
    private readonly IChatCompletionService _chatCompletionService;

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
        string result = "";
        await foreach (var messageContent in _chatCompletionService.GetStreamingChatMessageContentsAsync(
                           _history,
                           executionSettings: new PromptExecutionSettings
                           {
                               FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
                           },
                           kernel: _kernel))
        {
            Console.Write(messageContent.Content);
            result += messageContent.Content;
        }
        _history.AddAssistantMessage(result);
    }
    private static string SystemPrompt()
    {
        return """
               Context: You are an assistant integrated within a quote creation application named "CODE-C".
               
               ROLE: Your role is to create quotes when requested, using the tools available to you.
               
               When creating a quote, you must strictly follow the workflow below:
               
               Create an empty quote.
               
               Ask which client the user wants to associate with the quote. There are two possible types: person or organization.
               The user can choose from existing clients or create a new one. Therefore, you must ask if the client is a person or an organization.
               ⚠️ WARNING: THIS STEP IS MANDATORY BEFORE MOVING FORWARD.
               
               Ask for confirmation from the user to link the selected customer to the quote.
               
               Link the customer to the quote.
               
               Ask if the user wants to add a contact.
               
               If yes, ask whether they want to add an existing contact or create a new one.
               
               Ask for confirmation to link the contact to the quote.
               
               If confirmed, link the contact to the quote.
               
               ✅ After each step, confirm that the action was completed successfully.
               """;
    }

    private void AddPlugins()
    {
        _kernel.Plugins.AddFromType<QuotesPlugins>("Quotes");
        _kernel.Plugins.AddFromType<CustomersPlugin>("Customers");
        _kernel.Plugins.AddFromType<ContactsPlugin>("Contacts");
    }
}