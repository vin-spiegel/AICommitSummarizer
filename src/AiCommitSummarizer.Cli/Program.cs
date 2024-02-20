using AiCommitSummarizer.Cli;
using AiCommitSummarizer.Cli.Options;
using AiCommitSummarizer.Core;
using AiCommitSummarizer.Core.Core;
using AiCommitSummarizer.Core.Rules;
using AiCommitSummarizer.Core.Services;
using CommandLine;
// ReSharper disable ConvertToLambdaExpression

var arguments = Utils.GetCommandlineArguments();
var writerService = new WriterService();
var gitService = new GitService();

if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, ".git")))
{
    Console.WriteLine("There is no .git folder. Please run from a directory containing a .git folder. Exiting.");
    return 1;
}

if (arguments.Length == 0)
{
    while (!ApiKeyRules.IsValidKeyFromPath(Utils.GetApiKeySettingsPath()))
    {
        Console.WriteLine("Set your OpenAI API key using the set-api-key command.");
        var apiKey = Console.ReadLine();

        if (string.IsNullOrEmpty(apiKey))
        {
            Console.WriteLine("No API key provided. Exiting.");
            return 1;
        }
        writerService.SetApiKey(apiKey);
    }
    
    var commits = gitService.GetCurrentCommits();

    if (string.IsNullOrEmpty(commits))
    {
        Console.WriteLine("There are no recent commits. Existing.");
        return 1;
    }

    await Summarizer.Run(commits);
    return 1;
}
else
{
    Parser.Default.ParseArguments<SetOptions>(arguments)
        .WithParsed(opts =>
        {
            if (!opts.Set || string.IsNullOrEmpty(opts.SetValue)) 
                return;
            
            var parts = opts.SetValue.Split('=');

            if (parts.Length < 2)
                return;

            var key = parts[0];
            var value = parts[1];
                
            if (key == nameof(Config.OPEN_AI_KEY))
            {
                writerService.SetApiKey(value);
            }
        });
    return 0;
}
