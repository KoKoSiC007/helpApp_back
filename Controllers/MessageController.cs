using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupService.Interfaces.Message;
using SupService.Managers.Message;
using SupService.Models.Message;
using SupService.Models.Ticket;
using Update = SupService.Models.Message.Update;

namespace SupService.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageManager _manager;

        public MessageController(IMessageManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> Create(ICreate data)
        {
            return Ok(await _manager.Create(data));
        }

        [HttpPut("{id}")]
        public async Task<Message> Update(Update data)
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
        public async Task<IEnumerable<Message>> Index()
        {
            return await _manager.Get();
        }

        [HttpGet("{id}")]
        public async Task<Message> Show(string id)
        {
            return await _manager.Get(new Guid(id));
        }

        [HttpGet("search")]
        public async Task<IEnumerable<Message>> Search(string data)
        {
            return await _manager.Search(data);
        }

        [HttpGet("{id}/ticket")]
        public async Task<Ticket> GetTicket(string id)
        {
            return await _manager.Ticket(new Guid(id));
        }
    }
}