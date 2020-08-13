using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Portfolio.API.Models;
using Portfolio.API.Models.Dtos;
using Portfolio.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Portfolio.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService _dbService;

        public ProjectsController(IProjectService cosmosDbService)
        {
            _dbService = cosmosDbService;
        }

        [HttpGet]
        [ActionName("GetAll")]
        public async Task<IActionResult> GetAll() => Ok(await _dbService.GetAllAsync<Project>("SELECT * FROM c"));

        [HttpGet("{id}")]
        [ActionName("GetOne")]
        public async Task<IActionResult> GetOne([FromRoute] string id) => Ok(await _dbService.GetAsync<Project>(id));

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails([FromRoute] string id)
        {
            var project = await _dbService.GetAsync<Project>(id);
            if (project.Github != null && !project.IsPrivate)
            {
                var detailedProject = project.ToDetailed();
                var githubService = new GithubService(project.Github.User, project.Github.Repository);
                detailedProject.GithubContent.Commits = await githubService.GetCommits();
                detailedProject.GithubContent.Workflows = await githubService.GetWorkflows();
                
                return Ok(detailedProject);
            }
            else
            {
                return Ok(project);
            }

        }

        [HttpPost]
        [ActionName("create")]
        public async Task<IActionResult> Post([FromBody] CreateProjectDto project)
        {
            var p = project.ToProject();
            await _dbService.AddAsync(p);
            return CreatedAtAction("GetOne", new { p.Id });
        }

        [HttpPut("{id}")]
        [ActionName("update")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] Project project)
        {
            if (project.Id == id)
            {
                await _dbService.UpdateAsync(id, project);
                return NoContent();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ActionName("delete")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _dbService.DeleteAsync<Project>(id);
            return NoContent();
        }
    }
}
