using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Managers.Organization;
using SupService.Models.Client;
using SupService.Models.Organization;
using Create = SupService.Models.Organization.Create;
using Update = SupService.Models.Organization.Update;

namespace SupService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class OrganizationController : Controller
    {
        private readonly IOrganizationManager _manager;
        public OrganizationController(IOrganizationManager manager)
        {
            _manager = manager;
        }
        
        [HttpPost]
        public async Task<Organization> Create(Create data)
        {
            return await _manager.Create(data);
        }

        [HttpPut("{id}")]
        public async Task<Organization> Update(Update data)
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
        public async Task<IEnumerable<Organization>> Index()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Organization> Show(string id)
        {
            return await _manager.Get(new Guid(id));
        }

        [HttpGet("{id}/clients")]
        public async Task<IEnumerable<Client>> ShowClients(string id)
        {
            return await _manager.GetClients(new Guid(id));
        }
        
        [HttpGet("search")]
        public async Task<IEnumerable<Organization>> Search(string data)
        {
            return await _manager.Search(data);
        }
    }
}