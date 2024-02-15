using AiCommitSummarizer.Core.Core;
using AiCommitSummarizer.Core.Models;
using AiCommitSummarizer.Core.Serialization;

namespace AiCommitSummarizer.Core.Services;

public class OpenAiService
{
    public void SetApiKey(string apiKey, string organizationId = "")
    {
        File.WriteAllText(Utils.GetApiKeySettingsPath(), new CamelCaseJsonSerializer().Serialize(new OpenAiApiKeyModel
        {
            ApiKey = apiKey,
            Organization = organizationId
        }));
    }
}