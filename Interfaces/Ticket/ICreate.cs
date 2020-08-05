using System;

namespace SupService.Interfaces.Ticket
{
    public interface ICreate
    {
        string Description { get; set; }
        Guid ProjectId { get; set; }
        Guid ManagerId { get; set; }
    }
}