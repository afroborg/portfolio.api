using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models.Dtos
{
    public class CreateProjectDto
    {
        [Required]
        public string Name { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public IList<string> Languages { get; set; } = new List<string>();
        public bool IsPrivate { get; set; } = false;
        public bool HasAuthentication { get; set; } = false;
        public bool IsFullStack { get; set; } = false;

        public GithubInfo Github { get; set; }

        public Project ToProject() => new Project
        {
            Id = Guid.NewGuid().ToString(),
            Name = Name,
            Tags = Tags,
            Languages = Languages,
            IsPrivate = IsPrivate,
            HasAuthentication = HasAuthentication,
            IsFullStack = IsFullStack,
            Github = Github
        };
    }
}
