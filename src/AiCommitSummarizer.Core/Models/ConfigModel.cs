using AiCommitSummarizer.Core.Interfaces;

namespace AiCommitSummarizer.Core.Models;

[Serializable]
public class ConfigModel : ISavable
{
    public string? ApiKey { get; set; }
    public string? Organization { get; set; }
}