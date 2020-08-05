using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Ticket;

namespace SupService.Managers.Ticket
{
    public class TicketManager: ITicketManager
    {
        private readonly SupServiceContext _context;

        public TicketManager(SupServiceContext context)
        {
            _context = context;
        }
        public async Task<Models.Ticket.Ticket> Create(ICreate request)
        {
            var entity = new Models.Ticket.Ticket
            {
                Id = new Guid(),
                Description = request.Description,
                ManagerId = request.ManagerId,
                ProjectId = request.ProjectId
            };

            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Ticket.Ticket> Update(IUpdate request)
        {
            var entity = await _context.Tickets.FindAsync(request.Id);
            entity.Description = request.Description;
            entity.ManagerId = request.ManagerId;
            entity.ProjectId = request.ProjectId;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Models.Ticket.Ticket>> Get()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Models.Ticket.Ticket> Get(Guid id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<Models.Stuff.Stuff> GetManager(Guid id)
        {
            var entity = await _context.Tickets.FindAsync(id);
            return await _context.Managers.FindAsync(entity.ManagerId);
        }

        public async Task<IEnumerable<Models.Message.Message>> Messages(Guid id)
        {
            return await _context.Messages.Where(message => message.TicketId == id).ToListAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Ticket.Ticket>> Search(string word)
        {
            return await (from ticket in _context.Tickets
                where ticket.Id.ToString().Contains(word)
                      || ticket.Description.Contains(word)
                      || ticket.ManagerId.ToString().Contains(word)
                      || ticket.ProjectId.ToString().Contains(word)
                select ticket).ToListAsync();
        }
    }
}