using System;

namespace SupService.Interfaces.Message
{
    public interface ICreate
    {
        string Text { get; set; }
        byte[] CreatedAt { get; set; }
        Guid SenderId { get; set; }
        Guid TicketId { get; set; }
    }
}