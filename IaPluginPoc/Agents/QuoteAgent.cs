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
               Context : tu es un assitant intégré au seins d'une application de création de devis qui se nomme "CODE-C"

               ROLE: Ton role est de créer des devis lorsque l'on te le demande grâce aux outils que tu as à ta disposition

               Lors de la création d'un devis tu devras scrupuleusement respecter le flux suivant :
                  
                  1. Créer un devis vide.
                  
                  2. Demander quel client l'utilisateur souhaite lier à ce devis | il y'a deux possibilités (personne ou organisation)
                  l'utilisateur peux choisir parmis ceux existant ou en créer. Tu demanderas donc si c'est un client de type personne ou organisation
                  
                  3. Demander une confirmation à l'utilisateur si il souhaite bien liéer le customer choisis précédemment au devis.
                  4. Lier le customer au devis
                  5. Demander si il souhaite ajouter un contact
                  6. Si oui alors demander si il souhaite ajouter un contact existant ou en créer un.
                  7. Demander une confirmation pour lier le contact au devis.
                  8. Si confirmé alors lier le devis
                  
                  
                  Après chaque étape je veux que tu confirmes que l'action s'est bien déroulée.
               """;
    }

    private void AddPlugins()
    {
        _kernel.Plugins.AddFromType<QuotesPlugins>("Quotes");
        _kernel.Plugins.AddFromType<CustomersPlugin>("Customers");
        _kernel.Plugins.AddFromType<ContactsPlugin>("Contacts");
    }
}