using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Project;

namespace SupService.Managers.Project
{
    public interface IProjectManager
    {
        Task<Models.Project.Project> Create(ICreate request);
        Task<Models.Project.Project> Update(IUpdate request);
        Task<IEnumerable<Models.Project.Project>> Get();
        Task<Models.Project.Project> Get(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Models.Project.Project>> Search(string word);
    }
}