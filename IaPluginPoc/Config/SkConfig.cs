using Microsoft.SemanticKernel;

namespace IaPluginPoc.Config;

public static class SkConfig
{
    public static Kernel AddSk(this IKernelBuilder builder)
    {
        builder.AddOpenAIChatCompletion("gpt-4.1",
            new Uri("https://api.openai.com/v1"),
            "",
            serviceId: "code");

        return builder.Build();
    }
}