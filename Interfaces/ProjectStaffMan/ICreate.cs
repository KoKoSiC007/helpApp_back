using System;

namespace SupService.Interfaces.ProjectStaffMan
{
    public interface ICreate
    {
        string ManagerId { get; set; }
        string ProjectId { get; set; }
    }
}