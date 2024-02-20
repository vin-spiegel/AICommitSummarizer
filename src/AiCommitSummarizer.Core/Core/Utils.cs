namespace AiCommitSummarizer.Core.Core;

public static class Utils
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

    public static string[] GetCommandlineArguments()
    {
#if DEBUG
        return Environment.GetCommandLineArgs().Skip(1).ToArray();
#else
        return Environment.GetCommandLineArgs().ToArray();        
#endif
    }
}