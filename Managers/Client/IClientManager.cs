using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Client;

namespace SupService.Managers.Client
{
    public interface IClientManager
    {
        Task<Models.Client.Client> Create(ICreate request);
        Task<Models.Client.Client> Update(IUpdate request);
        Task<IEnumerable<Models.Client.Client>> Get();
        Task<Models.Client.Client> Get(Guid id);
        Task<IEnumerable<Models.Project.Project>> GetProjects(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Models.Client.Client>> Search(string data);
    }
}