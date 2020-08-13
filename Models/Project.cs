using Newtonsoft.Json;
using Portfolio.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models
{
    public class Project : IDIndexable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public IList<string> Tags { get; set; }
        [JsonProperty(PropertyName = "languages")]
        public IList<string> Languages { get; set; }
        [JsonProperty(PropertyName = "isPrivate")]
        public bool IsPrivate { get; set; }
        [JsonProperty(PropertyName = "hasAuthentication")]
        public bool HasAuthentication { get; set; }
        [JsonProperty(PropertyName = "isFullstack")]
        public bool IsFullStack { get; set; }
        [JsonProperty(PropertyName = "github")]
        public GithubInfo Github { get; set; }

        public DetailedProject ToDetailed() => new DetailedProject
        {
            Name = Name,
            Id = Id,
            Tags = Tags,
            Languages = Languages,
            IsPrivate = IsPrivate,
            HasAuthentication = HasAuthentication,
            IsFullStack = IsFullStack,
            Github = Github,
            GithubContent = new DetailedGithubInfo()
        };
    }

    public class GithubInfo
    {
        [JsonProperty(PropertyName = "user")]
        public string User { get; set; }
        [JsonProperty(PropertyName = "repository")]
        public string Repository { get; set; }
    }
}
