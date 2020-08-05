using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Message;

namespace SupService.Managers.Message
{
    public interface IMessageManager
    {
        Task<Models.Message.Message> Create(ICreate request);
        Task<Models.Message.Message> Update(IUpdate request);
        Task<IEnumerable<Models.Message.Message>> Get();
        Task<Models.Message.Message> Get(Guid id);
        Task<Models.Ticket.Ticket> Ticket(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Models.Message.Message>> Search(string data);
    }
}