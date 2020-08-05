using System;
using System.Threading.Tasks;
using SupService.Interfaces.ProjectStaffMan;

namespace SupService.Managers.ProjectStaffMan
{
    public interface IProjectStaffManager
    {
        Task AddProjectToManagerTask(ICreate request);
        Task AddManagerToProjectTask(ICreate request);
    }
}