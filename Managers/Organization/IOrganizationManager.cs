using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SupService.Interfaces.Organization;

namespace SupService.Managers.Organization
{
    public interface IOrganizationManager
    {
        Task<Models.Organization.Organization> Create(ICreate request);
        Task<Models.Organization.Organization> Update(IUpdate request);
        Task<IEnumerable<Models.Organization.Organization>> Get();
        Task<Models.Organization.Organization> Get(Guid id);
        Task<IEnumerable<Models.Client.Client>> GetClients(Guid id);
        Task Delete(Guid id);
        Task<IEnumerable<Models.Organization.Organization>> Search(string word);
    }
}