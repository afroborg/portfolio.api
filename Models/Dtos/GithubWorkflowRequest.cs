using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models.Dtos
{
    public class GithubWorkflowRequest
    {
        [JsonProperty("workflows")]
        public IList<GithubWorkflowRequestWorkflow> Workflows { get; set; }
    }

    public class GithubWorkflowRequestWorkflow
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("badge_url")]
        public string BadgeUrl { get; set; }
        [JsonProperty("html_url")]
        public string Url { get; set; }
    }
}
