  using System;
  using Newtonsoft.Json;

  namespace TestCrypto.MVVM.Models; 

  public class ReposUrl
  {
    [JsonProperty("github")]
    public Uri[] Github { get; set; }

    [JsonProperty("bitbucket")]
    public object[] Bitbucket { get; set; }
  }