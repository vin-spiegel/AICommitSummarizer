using CommandLine;
// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace AiCommitSummarizer.Cli.Options;

[Verb("set", HelpText = "Set your config.")]
public class SetOptions
{
    [Option('s', "set", Default = false, HelpText = "set options.")]
    public bool Set { get; set; }
    
    [Value(0)]
    public string? SetValue { get; set; }
}