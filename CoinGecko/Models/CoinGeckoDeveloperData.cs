using Newtonsoft.Json;

namespace CoinGecko.Models;

// Developer data
public class CoinGeckoDeveloperData
{
    // Forks
    public int? Forks { get; set; }
    
    // Stars
    public int? Stars { get; set; }
    
    // Subscribers
    public int? Subscribers { get; set; }
    
    // Total issues
    [JsonProperty("total_issues")]
    public int? TotalIssues { get; set; }
    
    // Closed issues
    [JsonProperty("closed_issues")]
    public int? ClosedIssues { get; set; }
    
    // Pull requests merged
    [JsonProperty("pull_requests_merged")]
    public int? PullRequestsMerged { get; set; }
    
    // Pull request contributors
    [JsonProperty("pull_request_contributors")]
    public int? PullRequestContributors { get; set; }
    
    // Code changes last 4 weeks
    [JsonProperty("code_additions_deletions_4_weeks")]
    public CoinGeckoCodeAddDel? CodeAdditionsDeletions4Weeks { get; set; }
    
    // Amount of commits last 4 weeks
    [JsonProperty("commit_count_4_weeks")]
    public int? CommitCount4Weeks { get; set; }
    
    // Commits series last 4 weeks
    [JsonProperty("last_4_weeks_commit_activity_series")]
    public IEnumerable<int> Last4WeeksCommitActivitySeries { get; set; } = new List<int>();
}