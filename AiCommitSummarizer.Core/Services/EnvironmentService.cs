using AiCommitSummarizer.Core.Core;
// ReSharper disable StringLiteralTypo

namespace AiCommitSummarizer.Core.Services;

public class EnvironmentService
{
    public void CreateEnvFolder()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var pathToFolder = Path.Combine(path, ".aicommitsummarizer");
        
        if (!Directory.Exists(pathToFolder))
        {
            Directory.CreateDirectory(pathToFolder);
        }
    }

    public void CreateEnvFile()
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".aicommitsummarizer/.env");
        if (!File.Exists(path))
        {
            File.Create(path).Close();
        }
    }

    public string Get(string key)
    {
        var envFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".aicommitsummarizer/.env");
        if (File.Exists(envFile))
        {
            var lines = File.ReadAllLines(envFile);
            foreach (var line in lines)
            {
                var parts = line.Split("=");
                if (parts[0] == key)
                {
                    return parts[1];
                }
            }
        }
        
        return string.Empty;
    }

    public void Set(string key, string value)
    {
        var envFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".aicommitsummarizer/.env");
        if (File.Exists(envFile))
        {
            var lines = File.ReadAllLines(envFile);
            for (var i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split("=");
                if (parts[0] == key)
                {
                    lines[i] = $"{key}={value}";
                    File.WriteAllLines(envFile, lines);
                    return;
                }
            }
        }
        else
        {
            File.WriteAllText(envFile, $"{key}={value}");
        }
    }
}