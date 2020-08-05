using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SupService.Models.Message
{
    public enum Sender
    {
        Manager,
        Client
    }
    public class Message
    {
        [Key] [Required] public Guid Id { get; set; }

        [Required] public string Text { get; set; }

        [Required] [Timestamp] public byte[] CreatedAt { get; set; }

        [Required] public Sender Sender { get; set; }
        
        [Required] public Guid SenderId { get; set; }

        [ForeignKey("TicketId")]
        public Ticket.Ticket Ticket { get; set; }
        public Guid TicketId { get; set; }
    }
}