﻿using AiCommitSummarizer.Core.Core;
using OpenAI;

namespace AiCommitSummarizer.Core.Rules;

public class ApiKeyRules
{
    public static bool IsValidKey()
    {
        var path = PathHelper.GetApiKeySettingsPath();
        try
        {
            var openAiClient = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(path));
            return true;
        }
        catch (Exception _)
        {
            Console.WriteLine("It is not a valid API key. Please set a valid API key.");
            return false;
        }
    }
}