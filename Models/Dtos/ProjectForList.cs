using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.API.Models.Dtos
{
    public class ProjectForList
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IList<string> Languages { get; set; }
        public bool IsPrivate { get; set; }
        public string DemoUrl { get; set; }
        public GithubInfo Github { get; set; }
    }
}
