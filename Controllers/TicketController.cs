using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Managers.Ticket;
using SupService.Models.Message;
using SupService.Models.Stuff;
using SupService.Models.Ticket;
using Create = SupService.Models.Ticket.Create;
using Update = SupService.Models.Ticket.Update;

namespace SupService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class TicketController : Controller
    {
        private readonly ITicketManager _manager;
        public TicketController(ITicketManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult<Ticket>> Create(Create data)
        {
            return Ok(await _manager.Create(data));
        }

        [HttpPut("{id}")]
        public async Task<Ticket> Update(Update data)
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
        public async Task<IEnumerable<Ticket>> Index()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Ticket> Show(string id)
        {
            return await _manager.Get(new Guid(id));
        }

        [HttpGet("search")]
        public async Task<IEnumerable<Ticket>> Search(string data)
        {
            return await _manager.Search(data);
        }

        [HttpGet("{id}/messages")]
        public async Task<IEnumerable<Message>> GetMessages(string id)
        {
            return await _manager.Messages(new Guid(id));
        }
        
        [HttpGet("{id}/manager")]
        public async Task<Stuff> GetManager(string id)
        {
            return await _manager.GetManager(new Guid(id));
        }
    }
}