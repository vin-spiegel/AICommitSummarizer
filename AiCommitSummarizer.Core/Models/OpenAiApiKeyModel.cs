namespace AiCommitSummarizer.Core.Models;

[Serializable]
public class OpenAiApiKeyModel
{
    public string? ApiKey { get; set; }
    public string? Organization { get; set; }
}