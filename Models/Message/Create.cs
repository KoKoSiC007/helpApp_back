using System;
using SupService.Interfaces.Message;

namespace SupService.Models.Message
{
    public class Create: ICreate
    {
        public string Text { get; set; }
        public byte[] CreatedAt { get; set; }
        public Guid SenderId { get; set; }
        public Guid TicketId { get; set; }
    }
}