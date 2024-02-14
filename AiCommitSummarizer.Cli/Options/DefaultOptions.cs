﻿using CommandLine;

namespace AiCommitSummarizer.Cli.Options;

[Verb("default", HelpText = "Default options.")]
public class DefaultOptions
{
    [Option('v', "verbose", Required = false, HelpText = "Set output to verbose messages.")]
    public bool Verbose { get; set; }
}