using Newtonsoft.Json;
using Portfolio.API.Models.Dtos;
using System.Collections.Generic;

namespace Portfolio.API.Models
{
    public class Project : IDIndexable
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "demoUrl")]
        public string DemoUrl { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
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
            Id = Id,
            Name = Name,
            Description = Description,
            Tags = Tags,
            Languages = Languages,
            IsPrivate = IsPrivate,
            HasAuthentication = HasAuthentication,
            IsFullStack = IsFullStack,
            Github = IsPrivate ? null : Github,
            DemoUrl = IsPrivate ? null : DemoUrl,
            GithubContent = IsPrivate ? null : new DetailedGithubInfo()
        };

        public ProjectForList ToList() => new ProjectForList
        {
            Id = Id,
            Name = Name,
            Languages = Languages,
            Github = IsPrivate ? null : Github,
            DemoUrl = IsPrivate ? null : DemoUrl,
            IsPrivate = IsPrivate
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
