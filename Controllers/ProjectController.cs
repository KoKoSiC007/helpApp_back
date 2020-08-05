using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Managers.Project;
using SupService.Models.Project;

namespace SupService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _manager;
        public ProjectController(IProjectManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<Project> Create(Create data)
        {
            return await _manager.Create(data);
        }

        [HttpPut("{id}")]
        public async Task<Project> Update(Update data)
        {
            return await _manager.Update(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _manager.Delete(new Guid(id));
            return Ok(id);
        }
        
        [HttpGet]
        public async Task<IEnumerable<Project>> Index()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Project> Show(string id)
        {
            return await _manager.Get(new Guid(id));
        }
        
        [HttpGet("search")]
        public async Task<IEnumerable<Project>> Search(string data)
        {
            return await _manager.Search(data);
        }
    }
}