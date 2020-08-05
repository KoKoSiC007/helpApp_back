using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Managers.Client;
using SupService.Models.Client;
using SupService.Models.Project;
using Create = SupService.Models.Client.Create;
using Update = SupService.Models.Client.Update;

namespace SupService.Controllers
{    
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IClientManager _manager;
        public ClientController(IClientManager manager)
        {
            _manager = manager;
        }
        [HttpPost]
        public async Task<ActionResult<Client>> Create(Create data)
        {
            return Ok(await _manager.Create(data));
        }

        [HttpPut("{id}")]
        public async Task<Client> Update(Update data)
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
        public async Task<IEnumerable<Client>> Index()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Client> Show(string id)
        {
            return await _manager.Get(new Guid(id));
        }

        [HttpGet("{id}/projects")]
        public async Task<IEnumerable<Project>> GetProjects(string id)
        {
            return await _manager.GetProjects(new Guid(id));
        }
        
        [HttpGet("search")]
        public async Task<IEnumerable<Client>> Search(string data)
        {
            return await _manager.Search(data);
        }
    }
}