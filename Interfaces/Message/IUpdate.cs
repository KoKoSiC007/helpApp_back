using System;

namespace SupService.Interfaces.Message
{
    public interface IUpdate
    {
        Guid Id { get; set; }
        string Text { get; set; }
        byte[] CreatedAt { get; set; }
        Guid SenderId { get; set; }
        Guid TicketId { get; set; }
    }
}