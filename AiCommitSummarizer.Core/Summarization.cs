using AiCommitSummarizer.Core.Core;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;

namespace AiCommitSummarizer.Core;

public class Summarization
{
    public static async Task Run(string commits)
    {
        var messages = Prompt.GetPrompt();
        messages.Add(new Message(Role.User, commits));
        
        var path = PathHelper.GetApiKeySettingsPath();
        var api = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(path));
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var choice = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        var summary = choice.FirstChoice;
        
        Console.WriteLine($"{summary.Message}");
    }
}