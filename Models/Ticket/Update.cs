using System;
using SupService.Interfaces.Ticket;

namespace SupService.Models.Ticket
{
    public class Update: IUpdate
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ManagerId { get; set; }
    }
}