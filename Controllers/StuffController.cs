using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Managers.ProjectStaffMan;
using SupService.Managers.Stuff;
using SupService.Models.Stuff;

namespace SupService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    [Route("api/[controller]/[action]")]
    public class StuffController : Controller
    {
        private readonly IStuffManager _stuffManager;
        private readonly IProjectStaffManager _projectStaffManager;
        
        public StuffController(IStuffManager stuffManager, IProjectStaffManager projectStaffManager)
        {
            _stuffManager = stuffManager;
            _projectStaffManager = projectStaffManager;
        }

        [HttpPost]
        public async Task<Stuff> Create(Create data)
        {
            return await _stuffManager.Create(data);
        }

        [HttpPut("{id}")]
        public async Task<Stuff> Update(Update data)
        {
            return await _stuffManager.Update(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _stuffManager.Delete(new Guid(id));
            return Ok(id);
        }

        [HttpGet]
        public async Task<IEnumerable<Stuff>> Index()
        {
            return await _stuffManager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Stuff> Show(string id)
        {
            return await _stuffManager.Get(new Guid(id));
        }
        
        [HttpPost]
        public async Task AddManagerToProject(Models.ProjectStaffMan.Create data)
        {
            await _projectStaffManager.AddManagerToProjectTask(data);
        }
    }
}