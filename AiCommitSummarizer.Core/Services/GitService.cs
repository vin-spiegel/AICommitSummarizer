using System.Text;
using LibGit2Sharp;

namespace AiCommitSummarizer.Core.Services;

public class GitService : IDisposable
{
    private readonly Repository _repo;
    private readonly StringBuilder _stringBuilder = new();

    public GitService()
    {
        try
        {
            _repo = new Repository(Environment.CurrentDirectory);
        }
        catch
        {
            // onError?.Invoke();
        }
    }
    
    public string GetCurrentCommits(int since = 7)
    {
        _stringBuilder.Clear();
        
        var commitLog = _repo.Commits.QueryBy(new CommitFilter
        {
            SortBy = CommitSortStrategies.Time,
            IncludeReachableFrom  = _repo.Head,
            FirstParentOnly = true,
        });
        
        foreach (var commit in commitLog)
        {
            if (commit.Author.When >= DateTimeOffset.Now.AddDays(-since))
            {
                var formattedDate = commit.Author.When.ToString("yyMMdd");
                var res = $"{formattedDate} - {commit.Author.Name} - {commit.MessageShort}";
                _stringBuilder.AppendLine(res);
            }
        }

        return _stringBuilder.ToString();
    }

    public void Dispose()
    {
        _repo.Dispose();
    }
}