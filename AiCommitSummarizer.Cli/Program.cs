using AiCommitSummarizer.Cli.Options;
using AiCommitSummarizer.Core;
using AiCommitSummarizer.Core.Core;
using AiCommitSummarizer.Core.Rules;
using AiCommitSummarizer.Core.Services;
using CommandLine;
// ReSharper disable ConvertToLambdaExpression

var arguments = Utils.GetCommandlineArguments();

if (arguments.Length == 0)
{
    if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, ".git")))
    {
        Console.WriteLine("There is no .git folder. Exiting.");
        return 1;
    }

    var openAi = new OpenAiService();
    var gitService = new GitService();

    while (!ApiKeyRules.IsValidKey())
    {
        Console.WriteLine("Set your OpenAI API key using the set-api-key command.");
        var apiKey = Console.ReadLine();

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("No API key provided. Exiting.");
            return 1;
        }
        openAi.SetApiKey(apiKey);
    }
    
    var commits = gitService.GetCurrentCommits();

    if (string.IsNullOrEmpty(commits))
    {
        Console.WriteLine("There is no recent commits. Existing.");
        return 1;
    }

    await Summarization.Run(commits);
    return 1;
}

return Parser.Default.ParseArguments<SetOptions>(arguments).MapResult((SetOptions opts) =>
{
    // todo: Add set-Api key function
    return 0;
}, (_) => 1);
