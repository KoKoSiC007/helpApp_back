using System;

namespace SupService.Models.ProjectStaffMan
{
    public class ProjectStuffMan
    {
        public Guid StaffId { get; set; }
        public Guid ProjectId { get; set; }
        public Stuff.Stuff Manager { get; set; }
        public Project.Project Project { get; set; }
    }
}