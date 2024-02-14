using AiCommitSummarizer.Cli.Options;
using AiCommitSummarizer.Core;
using AiCommitSummarizer.Core.Rules;
using AiCommitSummarizer.Core.Services;
using CommandLine;

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
    Console.WriteLine("최근 작업한 커밋이 없습니다.");
    return 1;
}

await Summarization.Run(commits);
return 1;

// var result = Parser.Default.ParseArguments<DefaultOptions, SetOptions>(Environment.GetCommandLineArgs().Skip(1).ToArray())
//     .MapResult(
//         (DefaultOptions opts) =>
//         {
//             if (opts.Verbose)
//             {
//                 Console.WriteLine("Verbose");
//                 return 0;
//             }
//
//             Console.WriteLine("Default");
//             return 0;
//         }, (SetOptions opts) =>
//         {
//             Console.WriteLine("SetApiKey");
//             return 0;
//         }, (errors) =>
//         {
//             return 1;
//         });
//
// return result;

