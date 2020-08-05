using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SupService.Interfaces.Message;
using SupService.Models.Message;

namespace SupService.Managers.Message
{
    public class MessageManager: IMessageManager
    {
        private readonly SupServiceContext _context;

        public MessageManager(SupServiceContext context)
        {
            _context = context;
        }
        public async Task<Models.Message.Message> Create(ICreate request)
        {
            var entity = new Models.Message.Message
            {
                Id = new Guid(),
                Text = request.Text,
                SenderId = request.SenderId,
                Sender = Sender.Manager,
                TicketId = request.TicketId,
            };

            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Models.Message.Message> Update(IUpdate request)
        {
            var entity = await _context.Messages.FindAsync(request.Id);
            entity.Text = request.Text;
            entity.SenderId = request.SenderId;
            entity.TicketId = request.TicketId;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Models.Message.Message>> Get()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Models.Message.Message> Get(Guid id)
        {
            return await _context.Messages.FindAsync(id);
        }

        public async Task<Models.Ticket.Ticket> Ticket(Guid id)
        {
            var entity = await _context.Messages.FindAsync(id);
            return await _context.Tickets.FindAsync(entity.TicketId);
        }

        public async Task Delete(Guid id)
        {
            var entity = await _context.Messages.FindAsync(id);
            _context.Messages.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Models.Message.Message>> Search(string word)
        {
            return await (from message in _context.Messages
                where message.Id.ToString().Contains(word)
                      || message.Text.Contains(word)
                      || message.SenderId.ToString().Contains(word)
                      || message.TicketId.ToString().Contains(word)
                      || message.CreatedAt.ToString().Contains(word)
                select message).ToListAsync();
        }
    }
}