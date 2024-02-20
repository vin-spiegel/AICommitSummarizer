using AiCommitSummarizer.Core.Core;
using AiCommitSummarizer.Core.Interfaces;
using AiCommitSummarizer.Core.Models;
using AiCommitSummarizer.Core.Serialization;

namespace AiCommitSummarizer.Core.Services;

public class WriterService
{
    private void Write(ISavable savable)
    {
        File.WriteAllText(Utils.GetApiKeySettingsPath(), new CamelCaseJsonSerializer().Serialize(savable));
    }

    public void SetApiKey(string apiKey, string organizationId = "")
    {
        File.WriteAllText(Utils.GetApiKeySettingsPath(), new CamelCaseJsonSerializer().Serialize(new ConfigModel
        {
            ApiKey = apiKey,
            Organization = organizationId
        }));
    }
}