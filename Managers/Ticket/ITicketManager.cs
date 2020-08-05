using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Ticket;

namespace SupService.Managers.Ticket
{
    public interface ITicketManager
    {
        Task<Models.Ticket.Ticket> Create(ICreate request);
        Task<Models.Ticket.Ticket> Update(IUpdate request);
        Task<IEnumerable<Models.Ticket.Ticket>> Get();
        Task<Models.Ticket.Ticket> Get(Guid id);
        Task<Models.Stuff.Stuff> GetManager(Guid id);
        Task<IEnumerable<Models.Message.Message>> Messages(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Models.Ticket.Ticket>> Search(string data);
    }
}