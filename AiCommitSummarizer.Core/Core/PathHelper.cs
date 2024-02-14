namespace AiCommitSummarizer.Core.Core;

public class PathHelper
{
    public static string GetApiKeySettingsPath()
    {
#if DEBUG
        return "./.openai";
#else
         var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
         var projectFolder = Path.Combine(appDataPath, "CommitGPT");

         if (!Directory.Exists(projectFolder))
         {
             Directory.CreateDirectory(projectFolder);
         }
         
         return Path.Combine(projectFolder, "secrets.openai");
#endif
    }
}