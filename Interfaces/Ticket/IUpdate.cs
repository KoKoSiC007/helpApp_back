using System;

namespace SupService.Interfaces.Ticket
{
    public interface IUpdate
    {
        Guid Id { get; set; }
        string Description { get; set; }
        Guid ProjectId { get; set; }
        Guid ManagerId { get; set; }
    }
}