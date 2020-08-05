using System;
using SupService.Interfaces.Ticket;

namespace SupService.Models.Ticket
{
    public class Create: ICreate
    {
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid ManagerId { get; set; }
    }
}