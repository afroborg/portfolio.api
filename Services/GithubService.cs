using Microsoft.AspNetCore.Http.Headers;
using Newtonsoft.Json;
using Portfolio.API.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Portfolio.API.Services
{
    public class GithubService
    {
        private const string GITHUB_API_URL = "https://api.github.com/";

        private readonly string _user;
        private readonly string _repository;
        private readonly HttpClient _client;

        public GithubService(string user, string repository)
        {
            _user = user;
            _repository = repository;
            _client = new HttpClient
            {
                BaseAddress = new Uri(GITHUB_API_URL)
            };
            _client.DefaultRequestHeaders.Add("User-Agent", "Axel.Portfolio.API");
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {Guid.NewGuid()}");
        }

        public async Task<List<GithubCommit>> GetCommits()
        {
            using var http = new HttpClient();
            

            var endpoint = $"repos/{_user}/{_repository}/commits";
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject<IList<GithubCommitRequest>>(await response.Content.ReadAsStringAsync()).ToList();

                if (json.Count > 3)
                    json = json.GetRange(0, 3);

                var list = new List<GithubCommit>(json.Select(g => new GithubCommit
                {
                    Message = g.Commit.Message,
                    Date = g.Commit.Author.Date,
                    Url = g.Url,
                    Author = new GithubCommitAuthor
                    {
                        Email = g.Commit.Author.Email,
                        Name = g.Commit.Author.Name,
                        PhotoUrl = g.Author.PhotoUrl,
                        Url = g.Author.Url,
                    }
                }));
                return list;
            }
            else
                return new List<GithubCommit>();

        }

        public async Task<List<GithubWorkflow>> GetWorkflows()
        {
            var endpoint = $"{GITHUB_API_URL}repos/{_user}/{_repository}/workflows";
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var json = JsonConvert.DeserializeObject<GithubWorkflowRequest>(await response.Content.ReadAsStringAsync());
                var list = new List<GithubWorkflow>(json.Workflows.Select(w => new GithubWorkflow
                {
                    Badge = w.BadgeUrl,
                    Name = w.Name,
                    Url = w.Url
                }));

                return list;
            }
            else
                return new List<GithubWorkflow>();
        }
    }
}
