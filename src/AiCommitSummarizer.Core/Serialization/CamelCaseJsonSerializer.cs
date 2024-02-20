using AiCommitSummarizer.Core.Interfaces;
using AiCommitSummarizer.Core.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AiCommitSummarizer.Core.Serialization;

public class CamelCaseJsonSerializer
{
    public string Serialize(ISavable model)
    {
        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        return JsonConvert.SerializeObject(model, settings);
    }
}