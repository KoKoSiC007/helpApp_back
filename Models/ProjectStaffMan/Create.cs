using System;
using SupService.Interfaces.ProjectStaffMan;

namespace SupService.Models.ProjectStaffMan
{
    public class Create: ICreate
    {
        public string ManagerId { get; set; }
        public string ProjectId { get; set; }
    }
}