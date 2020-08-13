using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Portfolio.API.Models.Dtos
{
    public class DetailedProject : Project
    {
        public DetailedGithubInfo GithubContent { get; set; }
    }

    public class DetailedGithubInfo
    {
        public IList<GithubCommit> Commits { get; set; } = new List<GithubCommit>();
        public IList<GithubWorkflow> Workflows { get; set; } = new List<GithubWorkflow>();
    }

    public class GithubCommit
    {
        public GithubCommitAuthor Author { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public string Url { get; set; }
    }
    public class GithubCommitAuthor
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public string Url { get; set; }
    }

    public class GithubWorkflow
    {
        public string Name { get; set; }
        public string Badge { get; set; }
        public string Url { get; set; }
    }
}
