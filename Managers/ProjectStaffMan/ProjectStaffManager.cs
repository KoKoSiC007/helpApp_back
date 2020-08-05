using System;
using System.Threading.Tasks;
using SupService.Interfaces.ProjectStaffMan;
using SupService.Models.ProjectStaffMan;

namespace SupService.Managers.ProjectStaffMan
{
    public class ProjectStaffManager: IProjectStaffManager
    {
        private readonly SupServiceContext _dbContext;

        public ProjectStaffManager(SupServiceContext context)
        {
            _dbContext = context;
        }
        public async Task AddProjectToManagerTask(ICreate request)
        {
            await Add(request);
        }

        public async Task AddManagerToProjectTask(ICreate request)
        {
            await Add(request);
        }

        private async Task Add(ICreate request)
        {
            var entity = new ProjectStuffMan
            {
                StaffId = new Guid(request.ManagerId),
                ProjectId = new Guid(request.ProjectId)
            };
            await _dbContext.ProjectStuffMans.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}