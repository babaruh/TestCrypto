using System;
using Newtonsoft.Json;

namespace TestCrypto.MVVM.Models;

public class Links
{
    [JsonProperty("homepage")]
    public string[] Homepage { get; set; }

    [JsonProperty("blockchain_site")]
    public string[] BlockchainSite { get; set; }

    [JsonProperty("official_forum_url")]
    public string[] OfficialForumUrl { get; set; }

    [JsonProperty("chat_url")]
    public string[] ChatUrl { get; set; }

    [JsonProperty("bitcointalk_thread_identifier")]
    public object BitcointalkThreadIdentifier { get; set; }

    [JsonProperty("subreddit_url")]
    public string SubredditUrl { get; set; }

    [JsonProperty("repos_url")]
    public ReposUrl ReposUrl { get; set; }
}