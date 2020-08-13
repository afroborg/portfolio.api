using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models.Dtos
{
    public class GithubCommitRequest
    {
        [JsonProperty("commit")]
        public GithubCommitRequestCommit Commit { get; set; }
        [JsonProperty("author")]
        public GithubCommitRequestAuthor Author { get; set; }
        [JsonProperty("html_url")]
        public string Url { get; set; }
    }

    public class GithubCommitRequestCommit
    {
        [JsonProperty("author")]
        public GithubCommitRequestCommitAuthor Author { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class GithubCommitRequestCommitAuthor
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
    }

    public class GithubCommitRequestAuthor
    {
        [JsonProperty("avatar_url")]
        public string PhotoUrl { get; set; }
        [JsonProperty("html_url")]
        public string Url { get; set; }

    }

}
